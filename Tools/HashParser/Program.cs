using CommandLine;
using CsvHelper;
using paracobNET;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace HashParser
{
    class Program
    {
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
                var dictHashes = GetParamLabels(o.InputParamLabelsFile);

                foreach (var file in filesPrc)
                {
                    var inputFileRelative = file.TrimStart(o.InputPath);
                    var outputFile = Path.Combine(o.OutputPath, inputFileRelative.TrimStart('\\').Replace('\\', Path.DirectorySeparatorChar) + ".csv");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputFile));

                    var output = new List<CsvEntry>();
                    var t = new ParamFile();
                    t.Open(file);

                    ParseStruct(output, t.Root.Nodes, dictHashes, string.Empty, string.Empty);

                    using (var writer = new StreamWriter(outputFile))
                    {
                        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            csv.WriteHeader<CsvEntry>();
                            csv.NextRecord();
                            foreach (var record in output)
                            {
                                csv.WriteRecord(record);
                                csv.NextRecord();
                            }
                        }
                    }
                }
            });
        }

        private static void ParseStruct(List<CsvEntry> csvEntries, Hash40Pairs<IParam> nodes, Dictionary<ulong, string> dictHashes, string fullPath, string listPath)
        {
            foreach (var prm in nodes)
            {
                if (prm.Value.TypeKey == ParamType.list)
                {
                    var list = (ParamList)prm.Value;
                    csvEntries.Add(new CsvEntry()
                    {
                        FullPath = fullPath,
                        ListPath = listPath,
                        KeyHexa = $"0x{prm.Key:x10}",
                        KeyLabel = GetHexaTitle(dictHashes, prm.Key),
                        Type = prm.Value.TypeKey.ToString(),
                        ValueLabel = list.Nodes.Count.ToString()
                    });
                    ParseList(csvEntries, list.Nodes, dictHashes, $"{fullPath}/{GetHexaTitle(dictHashes, prm.Key)}", $"{fullPath}/{GetHexaTitle(dictHashes, prm.Key)}");
                }
                else if (prm.Value.TypeKey == ParamType.hash40)
                {
                    var valueHex = (ulong)(prm.Value as ParamValue).Value;
                    csvEntries.Add(new CsvEntry()
                    {
                        FullPath = fullPath,
                        ListPath = listPath,
                        KeyHexa = $"0x{prm.Key:x10}",
                        KeyLabel = GetHexaTitle(dictHashes, prm.Key),
                        Type = prm.Value.TypeKey.ToString(),
                        ValueHexa = $"0x{valueHex:x10}",
                        ValueLabel = GetHexaTitle(dictHashes, valueHex)
                    });
                }
                else if (prm.Value.TypeKey == ParamType.@struct)
                {
                    ParseStruct(csvEntries, ((ParamStruct)prm.Value).Nodes, dictHashes, $"{fullPath}/{GetHexaTitle(dictHashes, prm.Key)}", $"{fullPath}/{GetHexaTitle(dictHashes, prm.Key)}");
                }
                else
                {
                    csvEntries.Add(new CsvEntry()
                    {
                        FullPath = fullPath,
                        ListPath = listPath,
                        KeyHexa = $"0x{prm.Key:x10}",
                        KeyLabel = GetHexaTitle(dictHashes, prm.Key),
                        Type = prm.Value.TypeKey.ToString(),
                        ValueLabel = ((ParamValue)prm.Value).Value.ToString()
                    });
                }
            }
        }

        private static void ParseList(List<CsvEntry> csvEntries, List<IParam> nodes, Dictionary<ulong, string> dictHashes, string fullPath, string listPath)
        {
            int i = 0;
            foreach (var prm in nodes)
            {
                if (prm.TypeKey == ParamType.list)
                {
                    var list = (ParamList)prm;
                    csvEntries.Add(new CsvEntry()
                    {
                        FullPath = fullPath,
                        ListPath = listPath,
                        KeyHexa = i.ToString(),
                        Type = prm.TypeKey.ToString(),
                        ValueLabel = list.Nodes.Count.ToString()
                    });
                    ParseList(csvEntries, list.Nodes, dictHashes, $"{fullPath}/{i}", fullPath);
                }
                else if (prm.TypeKey == ParamType.hash40)
                {
                    var valueHex = (ulong)(prm as ParamValue).Value;
                    csvEntries.Add(new CsvEntry()
                    {
                        FullPath = fullPath,
                        ListPath = listPath,
                        KeyLabel = i.ToString(),
                        Type = prm.TypeKey.ToString(),
                        ValueHexa = $"0x{valueHex:x10}",
                        ValueLabel = GetHexaTitle(dictHashes, valueHex)
                    });
                }
                else if (prm.TypeKey == ParamType.@struct)
                {
                    ParseStruct(csvEntries, ((ParamStruct)prm).Nodes, dictHashes, $"{fullPath}/{i}", fullPath);
                }
                else
                {
                    csvEntries.Add(new CsvEntry()
                    {
                        KeyHexa = i.ToString(),
                        Type = prm.TypeKey.ToString(),
                        ValueLabel = ((ParamValue)prm).Value.ToString()
                    });
                }
                i++;
            }
        }

        private static string GetHexaTitle(Dictionary<ulong, string> dict, ulong hexValue)
        {
            if (hexValue == 0)
                return string.Empty;

            return dict.ContainsKey(hexValue) ? dict[hexValue] : $"0x{hexValue:x10}";
        }

        private static Dictionary<ulong, string> GetParamLabels(string inputFileParamLabels)
        {
            var hashes = File.ReadAllLines(inputFileParamLabels);
            var output = new Dictionary<ulong, string>();

            foreach (var hash in hashes)
            {
                var hashSplit = hash.Split(",", StringSplitOptions.RemoveEmptyEntries);
                if (hashSplit.Length > 2)
                    throw new Exception("Bad ParamLabels");
                if (hashSplit.Length == 2)
                    output.Add(Convert.ToUInt64(hashSplit[0], 16), hashSplit[1]);
            }

            return output;
        }
    }
}
