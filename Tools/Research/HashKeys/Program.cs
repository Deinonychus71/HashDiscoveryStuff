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
    public class Program
    {
        private const string DICT_LIST = "List";
        private const string DICT_STRUCT = "Struct";
        private const string DICT_BOOLEAN = "Boolean";
        private const string DICT_HASH40KEY = "Hash40";
        private const string DICT_STRINGKEY = "String";
        private const string DICT_HASH40VALUE = "[Values]Hash40";
        private const string DICT_STRINGVALUE = "[Values]String";
        private const string DICT_FLOAT = "[Numeric]Float";
        private const string DICT_BYTE = "[Numeric]Byte";
        private const string DICT_INT = "[Numeric]Int";
        private const string DICT_SBYTE = "[Numeric]SByte";
        private const string DICT_SHORT = "[Numeric]Short";
        private const string DICT_UINT = "[Numeric]UInt";
        private const string DICT_USHORT = "[Numeric]UShort";
        private static int[] _listByHits = new int[] { 2, 3, 4, 5, 10, 15, 20 };

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed((o) =>
            {
                RunProgram(o);
            });
        }

        public static void RunProgram(Options o)
        {
            if (!Directory.Exists(o.InputSmashRootPath))
            {
                Console.WriteLine($"Directory '{o.InputSmashRootPath}' does not exist");
                return;
            }

            if (!File.Exists(o.InputParamLabelsFile))
            {
                Console.WriteLine($"File '{o.InputParamLabelsFile}' does not exist");
                return;
            }

            Directory.CreateDirectory(o.OutputPath);

            var filesPrc = Directory.GetFiles(o.InputSmashRootPath, "*.prc", SearchOption.AllDirectories).ToList();
            filesPrc.AddRange(Directory.GetFiles(o.InputSmashRootPath, "*.stprm", SearchOption.AllDirectories));
            filesPrc.AddRange(Directory.GetFiles(o.InputSmashRootPath, "*.stdat", SearchOption.AllDirectories));
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
                var inputFileRelative = file.TrimStart(o.InputSmashRootPath);
                if (includeFilters.Count > 0 && !includeFilters.Any(f => inputFileRelative.StartsWith(f)))
                    continue;
                if (excludeFilters.Any(f => inputFileRelative.StartsWith(f)))
                    continue;

                var t = new ParamFile();
                t.Open(file);

                ParseStruct(dictionaries, dictHashes, t.Root.Nodes);

                foreach (var dictKey in dictionaries.Keys.ToList())
                    dictionaries[dictKey] = dictionaries[dictKey].Distinct().ToList();
            }

            //Export
            foreach (var dictKey in dictionaries.Keys.ToList())
            {
                var allWords = WordsParsing.GetAllWords(dictionaries[dictKey]).Distinct().OrderBy(p => p);
                if (allWords.Any())
                {
                    File.WriteAllLines(Path.Combine(o.OutputPath, string.Format(o.FormatString, string.Empty, "[AllWords]", dictKey)), allWords.ToArray());
                    if (o.AddLastWordDic)
                    {
                        var lastWords = dictionaries[dictKey].Where(p => p.Contains("_")).Select(p => p.Substring(p.LastIndexOf("_") + 1)).Distinct().OrderBy(p => p);
                        if (lastWords.Any())
                        {
                            File.WriteAllLines(Path.Combine(o.OutputPath, string.Format(o.FormatString, string.Empty, "[LastWord]", dictKey)), lastWords.ToArray());

                            if (o.AddByHitsDic)
                            {
                                var groupedWords = WordsParsing.GetAllWords(lastWords, true, 2, -1, true).GroupBy(i => i, StringComparer.OrdinalIgnoreCase).ToDictionary(p => p.Key, p => p.Count());
                                foreach (var listByHitThreshold in _listByHits)
                                {
                                    var validWords = groupedWords.Where(p => p.Value >= listByHitThreshold);
                                    var listWords = validWords.Select(p => p.Key.ToLower());
                                    if (listWords.Any())
                                    {
                                        var key = dictKey.Contains("]") ? $"{dictKey.Replace("]", "][")}]" : $"[{dictKey}]";
                                        File.WriteAllLines(Path.Combine(o.OutputPath, string.Format(o.FormatString, $"[ByHits]", "[LastWord]", $"{key}AtLeast{listByHitThreshold:D2}")), listWords);
                                    }
                                }
                            }
                        }
                    }

                    if (o.AddByHitsDic)
                    {
                        var groupedWords = WordsParsing.GetAllWords(dictionaries[dictKey], true, 2, -1, true).GroupBy(i => i, StringComparer.OrdinalIgnoreCase).ToDictionary(p => p.Key, p => p.Count());
                        foreach (var listByHitThreshold in _listByHits)
                        {
                            var validWords = groupedWords.Where(p => p.Value >= listByHitThreshold);
                            var listWords = validWords.Select(p => p.Key.ToLower());
                            if (listWords.Any())
                            {
                                var key = dictKey.Contains("]") ? $"{dictKey.Replace("]", "][")}]" : $"[{dictKey}]";
                                File.WriteAllLines(Path.Combine(o.OutputPath, string.Format(o.FormatString, $"[ByHits]", "[AllWords]", $"{key}AtLeast{listByHitThreshold:D2}")), listWords);
                            }
                        }
                    }
                }
            }
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
    }
}
