using CommandLine;
using CsvHelper;
using paracobNET;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using HashCommon;
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
                var outputUncracked = new List<CsvEntry>();

                foreach (var file in filesPrc)
                {
                    var inputFileRelative = file.TrimStart(o.InputPath);
                    var outputFile = Path.Combine(o.OutputPath, inputFileRelative.TrimStart('\\').Replace('\\', Path.DirectorySeparatorChar) + ".csv");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputFile));

                    var output = new List<CsvEntry>();
                    var t = new ParamFile();
                    t.Open(file);

                    if(o.TrackUncracked)
                        ParseStruct(outputUncracked, t.Root.Nodes, dictHashes, inputFileRelative, string.Empty, string.Empty, o.TrackUncracked);
                    else
                        ParseStruct(output, t.Root.Nodes, dictHashes, inputFileRelative, string.Empty, string.Empty, o.TrackUncracked);

                    if (!o.TrackUncracked)
                    {
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
                }

                if (o.TrackUncracked)
                {
                    var groupedKeys = outputUncracked.Where(p => p.KeyHexa != null && p.KeyLabel.StartsWith("0x")).GroupBy(p => p.KeyLabel).Select(p => new CsvEntryUncracked()
                    {
                        Hex = p.Key,
                        KeyOrValue = "Key",
                        Type = string.Join(" | ", p.Select(p2 => p2.Type).Distinct().Take(10)),
                        FilePaths = string.Join(" | ", p.Select(p2 => p2.FilePath).Distinct().Take(10))
                    });
                    var groupedValues = outputUncracked.Where(p => p.ValueHexa != null && p.ValueLabel.StartsWith("0x")).GroupBy(p => p.ValueLabel).Select(p => new CsvEntryUncracked()
                    {
                        Hex = p.Key,
                        KeyOrValue = "Value",
                        Type = string.Join(" | ", p.Select(p2 => p2.Type).Distinct().Take(10)),
                        FilePaths = string.Join(" | ", p.Select(p2 => p2.FilePath).Distinct().Take(10))
                    });
                    var grouped = new List<CsvEntryUncracked>();
                    grouped.AddRange(groupedKeys);
                    grouped.AddRange(groupedValues);

                    //Double check
                    foreach(var group in grouped)
                    {
                        var test = GetHexaLabel(dictHashes, Convert.ToUInt64(group.Hex, 16));
                        if (!test.StartsWith("0x"))
                            Console.WriteLine("uncracked_hashes_grouped.csv");
                    }

                    //Generate uncracked_hashes_grouped.csv
                    using (var writer = new StreamWriter("uncracked_hashes_grouped.csv"))
                    {
                        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            csv.WriteHeader<CsvEntryUncracked>();
                            csv.NextRecord();
                            foreach (var record in grouped)
                            {
                                csv.WriteRecord(record);
                                csv.NextRecord();
                            }
                        }
                    }

                    //Generate uncracked_hashes.csv
                    using (var writer = new StreamWriter("uncracked_hashes.csv"))
                    {
                        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            csv.WriteHeader<CsvEntry>();
                            csv.NextRecord();
                            foreach (var record in outputUncracked)
                            {
                                csv.WriteRecord(record);
                                csv.NextRecord();
                            }
                        }
                    }
                }
            });
        }

        private static void ParseStruct(List<CsvEntry> csvEntries, Hash40Pairs<IParam> nodes, Dictionary<ulong, string> dictHashes, string filePath, string fullPath, string listPath, bool uncrackedOnly)
        {
            foreach (var prm in nodes)
            {
                if (prm.Value.TypeKey == ParamType.list)
                {
                    var list = (ParamList)prm.Value;
                    string keyLabel = GetHexaLabel(dictHashes, prm.Key);
                    if (!uncrackedOnly || keyLabel.StartsWith("0x"))
                    {
                        csvEntries.Add(new CsvEntry()
                        {
                            FilePath = filePath,
                            FullPath = fullPath,
                            ListPath = listPath,
                            KeyHexa = $"0x{prm.Key:x10}",
                            KeyLabel = keyLabel,
                            Type = prm.Value.TypeKey.ToString(),
                            ValueLabel = list.Nodes.Count.ToString()
                        });
                    }
                    ParseList(csvEntries, list.Nodes, dictHashes, filePath, $"{fullPath}/{GetHexaLabel(dictHashes, prm.Key)}", $"{fullPath}/{GetHexaLabel(dictHashes, prm.Key)}", uncrackedOnly);
                }
                else if (prm.Value.TypeKey == ParamType.hash40)
                {
                    var valueHex = (ulong)(prm.Value as ParamValue).Value;
                    string keyLabel = GetHexaLabel(dictHashes, prm.Key);
                    string valueLabel = GetHexaLabel(dictHashes, valueHex);
                    if (!uncrackedOnly || keyLabel.StartsWith("0x") || valueLabel.StartsWith("0x"))
                    {
                        csvEntries.Add(new CsvEntry()
                        {
                            FilePath = filePath,
                            FullPath = fullPath,
                            ListPath = listPath,
                            KeyHexa = $"0x{prm.Key:x10}",
                            KeyLabel = keyLabel,
                            Type = prm.Value.TypeKey.ToString(),
                            ValueHexa = $"0x{valueHex:x10}",
                            ValueLabel = valueLabel
                        });
                    }
                }
                else if (prm.Value.TypeKey == ParamType.@struct)
                {
                    ParseStruct(csvEntries, ((ParamStruct)prm.Value).Nodes, dictHashes, filePath, $"{fullPath}/{GetHexaLabel(dictHashes, prm.Key)}", $"{fullPath}/{GetHexaLabel(dictHashes, prm.Key)}", uncrackedOnly);
                }
                else
                {
                    string keyLabel = GetHexaLabel(dictHashes, prm.Key);
                    if (!uncrackedOnly || keyLabel.StartsWith("0x"))
                    {
                        csvEntries.Add(new CsvEntry()
                        {
                            FilePath = filePath,
                            FullPath = fullPath,
                            ListPath = listPath,
                            KeyHexa = $"0x{prm.Key:x10}",
                            KeyLabel = keyLabel,
                            Type = prm.Value.TypeKey.ToString(),
                            ValueLabel = ((ParamValue)prm.Value).Value.ToString()
                        });
                    }
                }
            }
        }

        private static void ParseList(List<CsvEntry> csvEntries, List<IParam> nodes, Dictionary<ulong, string> dictHashes, string filePath, string fullPath, string listPath, bool uncrackedOnly)
        {
            int i = 0;
            foreach (var prm in nodes)
            {
                if (prm.TypeKey == ParamType.list)
                {
                    var list = (ParamList)prm;
                    if (!uncrackedOnly)
                    {
                        csvEntries.Add(new CsvEntry()
                        {
                            FilePath = filePath,
                            FullPath = fullPath,
                            ListPath = listPath,
                            KeyHexa = i.ToString(),
                            Type = prm.TypeKey.ToString(),
                            ValueLabel = list.Nodes.Count.ToString()
                        });
                    }
                    ParseList(csvEntries, list.Nodes, dictHashes, filePath, $"{fullPath}/{i}", fullPath, uncrackedOnly);
                }
                else if (prm.TypeKey == ParamType.hash40)
                {
                    var valueHex = (ulong)(prm as ParamValue).Value;
                    string valueLabel = GetHexaLabel(dictHashes, valueHex);
                    if (!uncrackedOnly || valueLabel.StartsWith("0x"))
                    {
                        csvEntries.Add(new CsvEntry()
                        {
                            FilePath = filePath,
                            FullPath = fullPath,
                            ListPath = listPath,
                            KeyLabel = i.ToString(),
                            Type = prm.TypeKey.ToString(),
                            ValueHexa = $"0x{valueHex:x10}",
                            ValueLabel = valueLabel
                        });
                    }
                }
                else if (prm.TypeKey == ParamType.@struct)
                {
                    ParseStruct(csvEntries, ((ParamStruct)prm).Nodes, dictHashes, filePath, $"{fullPath}/{i}", fullPath, uncrackedOnly);
                }
                else
                {
                    if (!uncrackedOnly)
                    {
                        csvEntries.Add(new CsvEntry()
                        {
                            FilePath = filePath,
                            KeyHexa = i.ToString(),
                            Type = prm.TypeKey.ToString(),
                            ValueLabel = ((ParamValue)prm).Value.ToString()
                        });
                    }
                }
                i++;
            }
        }

        private static string GetHexaLabel(Dictionary<ulong, string> dict, ulong hexValue)
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
