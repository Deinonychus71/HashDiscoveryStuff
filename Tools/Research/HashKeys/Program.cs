using CommandLine;
using HashCommon;
using paracobNET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HashKeys
{
    /// <summary>
    /// Split the paramlabel words using different value types to make dictionary. Require prc/stprm/stdat files.
    /// </summary>
    class Program
    {
        private const string DICT_LIST = "[Keys]List";
        private const string DICT_STRUCT = "[Keys]Struct";
        private const string DICT_BOOLEAN = "[Keys]Boolean";
        private const string DICT_HASH40KEY = "[Keys]Hash40";
        private const string DICT_STRINGKEY = "[Keys]String";
        private const string DICT_HASH40VALUE = "[Values]Hash40";
        private const string DICT_STRINGVALUE = "[Values]String";
        private const string DICT_FLOAT = "[Keys][Numeric]Float";
        private const string DICT_BYTE = "[Keys][Numeric]Byte";
        private const string DICT_INT = "[Keys][Numeric]Int";
        private const string DICT_SBYTE = "[Keys][Numeric]SByte";
        private const string DICT_SHORT = "[Keys][Numeric]Short";
        private const string DICT_UINT = "[Keys][Numeric]UInt";
        private const string DICT_USHORT = "[Keys][Numeric]UShort";
        private static readonly char[] _splitChars = new char[] { ',', '.', '\\', '/', '_' };

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed((o) =>
            {
                if (!Directory.Exists(o.InputPath))
                {
                    Console.WriteLine($"Directory '{o.InputPath}' does not exist");
                    return;
                }

                if (!File.Exists(o.InputParamLabelsFile))
                {
                    Console.WriteLine($"File '{o.InputParamLabelsFile}' does not exist");
                    return;
                }

                Directory.CreateDirectory(o.OutputPath);

                var filesPrc = Directory.GetFiles(o.InputPath, "*.prc", SearchOption.AllDirectories).ToList();
                filesPrc.AddRange(Directory.GetFiles(o.InputPath, "*.stprm", SearchOption.AllDirectories));
                filesPrc.AddRange(Directory.GetFiles(o.InputPath, "*.stdat", SearchOption.AllDirectories));
                var dictHashes = HashHelper.GetParamLabels(o.InputParamLabelsFile);

                var dictionaries = new Dictionary<string, List<string>>()
                {
                    { DICT_LIST, new List<string>() },
                    { DICT_STRUCT, new List<string>() },
                    { DICT_BOOLEAN, new List<string>() },
                    { DICT_BYTE, new List<string>() },
                    { DICT_SBYTE, new List<string>() },
                    { DICT_SHORT, new List<string>() },
                    { DICT_FLOAT, new List<string>() },
                    { DICT_INT, new List<string>() },
                    { DICT_UINT, new List<string>() },
                    { DICT_USHORT, new List<string>() },
                    { DICT_HASH40KEY, new List<string>() },
                    { DICT_STRINGKEY, new List<string>() },
                    { DICT_HASH40VALUE, new List<string>() },
                    { DICT_STRINGVALUE, new List<string>() },
                };

                var excludeFilters = o.ExcludeFilterPath?.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToList();
                if (excludeFilters == null)
                    excludeFilters = new List<string>();
                var includeFilters = o.IncludeFilterPath?.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToList();
                if (includeFilters == null)
                    includeFilters = new List<string>();

                //Get all words
                foreach (var file in filesPrc)
                {
                    var inputFileRelative = file.TrimStart(o.InputPath);
                    if (includeFilters.Count > 0 && !includeFilters.Any(f => inputFileRelative.StartsWith(f)))
                        continue;
                    if (excludeFilters.Any(f => inputFileRelative.StartsWith(f)))
                        continue;

                    var t = new ParamFile();
                    t.Open(file);

                    ParseStruct(dictionaries, dictHashes, t.Root.Nodes);

                    foreach(var dictKey in dictionaries.Keys.ToList())
                        dictionaries[dictKey] = dictionaries[dictKey].Distinct().ToList();
                }

                //Export
                foreach (var dictKey in dictionaries.Keys.ToList())
                {
                    var allWords = GetAllWords(dictionaries[dictKey]).Distinct().OrderBy(p => p);
                    File.WriteAllLines(Path.Combine(o.OutputPath, string.Format(o.FormatString, dictKey)), allWords.ToArray());
                }
            });
        }

        private static void ParseStruct(Dictionary<string, List<string>> dictionaries, Dictionary<ulong, string> dictHashes, Hash40Pairs<IParam> nodes)
        {
            foreach (var prm in nodes)
            {
                ParseIParam(dictionaries, dictHashes, prm.Key, prm.Value);
            }
        }

        private static void ParseList(Dictionary<string, List<string>> dictionaries, Dictionary<ulong, string> dictHashes, List<IParam> nodes)
        {
            foreach (var prm in nodes)
            {
                if (prm.TypeKey == ParamType.list)
                {
                    var list = (ParamList)prm;
                    ParseList(dictionaries, dictHashes, list.Nodes);
                }
                else if (prm.TypeKey == ParamType.@struct)
                {
                    ParseStruct(dictionaries, dictHashes, ((ParamStruct)prm).Nodes);
                }
                else if (prm.TypeKey == ParamType.hash40)
                {
                    var valueHex = (ulong)(prm as ParamValue).Value;
                    AddHexaLabel(dictionaries[DICT_HASH40VALUE], dictHashes, valueHex);
                }
                else if (prm.TypeKey == ParamType.@string)
                {
                    dictionaries[DICT_STRINGVALUE].Add(((ParamValue)prm).Value.ToString());
                }
                else
                {
                    //Do nothing
                }
            }
        }

        private static void ParseIParam(Dictionary<string, List<string>> dictionaries, Dictionary<ulong, string> dictHashes, ulong prmKey, IParam prmValue)
        {
            if (prmValue.TypeKey == ParamType.list)
            {
                var list = (ParamList)prmValue;
                AddHexaLabel(dictionaries[DICT_LIST], dictHashes, prmKey);
                ParseList(dictionaries, dictHashes, list.Nodes);
            }
            else if (prmValue.TypeKey == ParamType.@struct)
            {
                AddHexaLabel(dictionaries[DICT_STRUCT], dictHashes, prmKey);
                ParseStruct(dictionaries, dictHashes, ((ParamStruct)prmValue).Nodes);
            }
            else if (prmValue.TypeKey == ParamType.hash40)
            {
                var valueHex = (ulong)(prmValue as ParamValue).Value;
                AddHexaLabel(dictionaries[DICT_HASH40KEY], dictHashes, prmKey);
                AddHexaLabel(dictionaries[DICT_HASH40VALUE], dictHashes, valueHex);
            }
            else if (prmValue.TypeKey == ParamType.@bool)
            {
                AddHexaLabel(dictionaries[DICT_BOOLEAN], dictHashes, prmKey);
            }
            else if (prmValue.TypeKey == ParamType.@byte)
            {
                AddHexaLabel(dictionaries[DICT_BYTE], dictHashes, prmKey);
            }
            else if (prmValue.TypeKey == ParamType.@float)
            {
                AddHexaLabel(dictionaries[DICT_FLOAT], dictHashes, prmKey);
            }
            else if (prmValue.TypeKey == ParamType.@int)
            {
                AddHexaLabel(dictionaries[DICT_INT], dictHashes, prmKey);
            }
            else if (prmValue.TypeKey == ParamType.@sbyte)
            {
                AddHexaLabel(dictionaries[DICT_SBYTE], dictHashes, prmKey);
            }
            else if (prmValue.TypeKey == ParamType.@short)
            {
                AddHexaLabel(dictionaries[DICT_SHORT], dictHashes, prmKey);
            }
            else if (prmValue.TypeKey == ParamType.@string)
            {
                AddHexaLabel(dictionaries[DICT_STRINGKEY], dictHashes, prmKey);
                dictionaries[DICT_STRINGVALUE].Add(((ParamValue)prmValue).Value.ToString());
            }
            else if (prmValue.TypeKey == ParamType.@uint)
            {
                AddHexaLabel(dictionaries[DICT_UINT], dictHashes, prmKey);
            }
            else if (prmValue.TypeKey == ParamType.@ushort)
            {
                AddHexaLabel(dictionaries[DICT_USHORT], dictHashes, prmKey);
            }
        }

        private static void AddHexaLabel(List<string> dict, Dictionary<ulong, string> dictHashes, ulong hexValue)
        {
            if (hexValue == 0 || !dictHashes.ContainsKey(hexValue))
                return;

            dict.Add(dictHashes[hexValue]);
        }

        private static IEnumerable<string> GetAllWords(IEnumerable<string> lines, bool skipDigits = false, int minLength = -1, int maxLength = -1, bool keepDouble = false)
        {
            var output = new List<string>();
            foreach (var line in lines)
            {
                var splitWords = SplitWords(new string[1] { line }, 0).Distinct();
                foreach (var splitWord in splitWords)
                {
                    if (minLength != -1 && splitWord.Length < minLength)
                        continue;

                    if (maxLength != -1 && splitWord.Length > maxLength)
                        continue;

                    if (skipDigits && !splitWord.All(char.IsLetter))
                        continue;

                    if (keepDouble || (!keepDouble && !output.Contains(splitWord)))
                        output.Add(splitWord);
                }
            }
            return output;
        }

        private static IEnumerable<string> SplitWords(IEnumerable<string> input, int currentIndex)
        {
            if (currentIndex < _splitChars.Length)
            {
                input = input.SelectMany(p => p.Split(_splitChars[currentIndex], System.StringSplitOptions.RemoveEmptyEntries));
                return SplitWords(input, currentIndex + 1);
            }
            return input;
        }
    }
}
