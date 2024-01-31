using CommandLine;
using CsvHelper;
using HashCommon;
using HashCommon.Models;
using HashRelationalResearch.Models;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;

namespace HashRelationalResearch
{
    class Program
    {
        private static readonly string[] _functionExclude = ["{", "}", "//", "#", " ", "LAB", "joined", "code", "switch"];
        private static readonly char[] _seekHexSeparators = [' ', ',', ')', '(', '[', ']', '{', '}', ';', ':', 'U'];

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed((o) =>
            {
                RunProgram(o);
            });
        }

        public static void RunProgram(Options o)
        {
            Console.WriteLine($"----------------------------------------------------");
            Console.WriteLine($"----------- GhidraMainExtractUniqueHexes -----------");
            Console.WriteLine($"----------------------------------------------------");

            var dictHashInfo = new Dictionary<string, HashInfo>();
            var exportEntries = new Dictionary<string, ExportEntry>();

            //Load ParamLabels
            Console.WriteLine($"Loading ParamLabels '{o.InputParamLabelsFile}'...");
            AppendToHashInfo(dictHashInfo, File.ReadAllLines(o.InputParamLabelsFile).Select(p => p.Split(',', StringSplitOptions.RemoveEmptyEntries)).Where(p => p.Length == 2).ToDictionary(p => p[0], p => p[1]), "ParamLabels");
            Console.WriteLine($"Loading MotionList '{o.InputFileMotionListLabels}'...");
            AppendToHashInfo(dictHashInfo, GetHashFile(o.InputFileMotionListLabels, ['/', '.'], true), "MotionList");
            Console.WriteLine($"Loading Paths '{o.InputFilePathHashes}'...");
            AppendToHashInfo(dictHashInfo, GetHashFile(o.InputFilePathHashes, ['/'], true), "Paths");
            Console.WriteLine($"Loading SoundInfo '{o.InputFileSoundLabelInfo}'...");
            AppendToHashInfo(dictHashInfo, GetHashFile(o.InputFileSoundLabelInfo, ['/', '.'], true), "SoundInfo");
            Console.WriteLine($"Loading SQB '{o.InputFileSQBLabels}'...");
            AppendToHashInfo(dictHashInfo, GetHashFile(o.InputFileSQBLabels, ['/', '.'], true), "SQB");
            Console.WriteLine($"Loading Effects '{o.InputFileEffectsLabels}'...");
            AppendEffectsFileToHashInfo(dictHashInfo, o.InputFileEffectsLabels, "Effects");

            //var file = JsonSerializer.Deserialize<ExportContainer>(File.ReadAllText(o.OutputFileJSON));
            //GenerateCSV(o, dictHashInfo, file);

            //Process PRC
            ProcessPRCFiles(o, dictHashInfo, exportEntries);

            //Process C Files
            var exportFunctions = new Dictionary<string, List<ExportFunctionEntry>>();
            ProcessCFiles(o, dictHashInfo, exportEntries, exportFunctions);

            //Export file
            var exportContainer = new ExportContainer() { ExportEntries = exportEntries, ExportFunctions = exportFunctions, HashLabels = dictHashInfo };

            //Generate Json
            if (!string.IsNullOrEmpty(o.OutputFileJSON))
            {
                Console.WriteLine($"Writing to JSON '{o.OutputFileJSON}'...");
                File.WriteAllText(o.OutputFileJSON, JsonSerializer.Serialize(exportContainer));
            }

            //Generate Bin
            if (!string.IsNullOrEmpty(o.OutputFileBIN))
            {
                Console.WriteLine($"Writing to BIN '{o.OutputFileBIN}'...");
                using (var fileStream = File.Create(o.OutputFileBIN))
                {
                    using (var compressionStream = new GZipStream(fileStream, CompressionLevel.SmallestSize))
                    {
                        Serializer.Serialize(compressionStream, exportContainer);
                    }
                }
            }

            //Generate CSV
            GenerateCSV(o, dictHashInfo, exportContainer);

            Console.WriteLine($"Found {exportEntries.Count} hashes");
            Console.WriteLine("DONE!");
            Console.ReadLine();
        }

        private static Dictionary<string, string> GetHashFile(string input, char[] splitChars, bool useCache = false)
        {
            var cachedFile = $"{input}.hash";
            if (useCache && File.Exists(cachedFile))
            {
                var cachedLines = File.ReadAllLines(cachedFile);
                return cachedLines.Select(p => p.Split(',', StringSplitOptions.RemoveEmptyEntries)).Where(p => p.Length > 1).ToDictionary(p => p[0], p => p[1]);
            }

            var hexes = new Dictionary<string, string>();
            var lines = File.ReadAllLines(input);
            foreach (var line in lines)
            {
                var hexString = HashHelper.ToHash40(line);
                hexes.TryAdd(hexString, line);

                var allWords = WordsParsing.SplitWords(line, splitChars);
                foreach (var word in allWords)
                {
                    var hexString2 = HashHelper.ToHash40(word);
                    hexes.TryAdd(hexString2, word);
                }
            }

            File.WriteAllLines(cachedFile, hexes.OrderBy(p => p.Value).Select(p => $"{p.Key},{p.Value}"));
            return hexes;
        }

        private static void AppendEffectsFileToHashInfo(Dictionary<string, HashInfo> dictHashInfo, string input, string source)
        {
            List<CSVEffect> csvEffects = null;

            using (var reader = new StreamReader(input))
            {
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                csvEffects = csv.GetRecords<CSVEffect>().ToList();
            }

            foreach (var csvEffect in csvEffects)
            {
                var value = csvEffect.Name.ToLower();
                var hexString = HashHelper.ToHash40(value);
                if (!dictHashInfo.TryGetValue(hexString, out HashInfo hashInfo))
                {
                    hashInfo = new HashInfo()
                    {
                        Label = value,
                        Hash40Hex = hexString
                    };
                    dictHashInfo.Add(hexString, hashInfo);
                }

                if (!hashInfo.Sources.Contains(source))
                    hashInfo.Sources.Add(source);
                if (!hashInfo.DetailedSources.Contains(csvEffect.Path))
                    hashInfo.DetailedSources.Add(csvEffect.Path);
            }
        }

        private static void AppendToHashInfo(Dictionary<string, HashInfo> dictHashInfo, Dictionary<string, string> dictHashes, string source, string detailedSource = null)
        {
            foreach (var dictHashesEntry in dictHashes)
            {
                if (!dictHashInfo.TryGetValue(dictHashesEntry.Key, out HashInfo hashInfo))
                {
                    hashInfo = new HashInfo()
                    {
                        Label = dictHashesEntry.Value,
                        Hash40Hex = dictHashesEntry.Key
                    };
                    dictHashInfo.Add(dictHashesEntry.Key, hashInfo);
                }

                if (!hashInfo.Sources.Contains(source))
                    hashInfo.Sources.Add(source);
                if (detailedSource != null && !hashInfo.DetailedSources.Contains(detailedSource))
                    hashInfo.DetailedSources.Add(detailedSource);
            }
        }

        private static void ProcessPRCFiles(Options o, Dictionary<string, HashInfo> dictHashInfo, Dictionary<string, ExportEntry> exportEntries)
        {
            //Load PRC
            var paramLabels = HashHelper.GetParamLabels(o.InputParamLabelsFile);
            var filesPrc = Directory.GetFiles(o.InputPrcRootPath, "*.prc", SearchOption.AllDirectories).ToList();
            filesPrc.AddRange(Directory.GetFiles(o.InputPrcRootPath, "*.stprm", SearchOption.AllDirectories));
            filesPrc.AddRange(Directory.GetFiles(o.InputPrcRootPath, "*.stdat", SearchOption.AllDirectories));

            //Process PRC
            var addedHashes = new HashSet<string>();
            Console.WriteLine($"Processing {filesPrc.Count} PRC/STPRM/STDAT files...");
            foreach (var file in filesPrc)
            {
                var inputFileRelative = file.TrimStart(o.InputPrcRootPath);
                var prcFile = PrcParser.ParsePrcFile(file, paramLabels);
                var allNodes = prcFile.GetAllNodes().Where(p => p.HashKeyValue > 0);
                addedHashes.Clear();
                foreach (var node in allNodes)
                {
                    //Key
                    var hashKeyFormatted = HashHelper.ToHash40(node.HashKeyValue);

                    if (!addedHashes.Contains(hashKeyFormatted))
                    {
                        if (!exportEntries.TryGetValue(hashKeyFormatted, out ExportEntry exportKeyEntry))
                        {
                            exportKeyEntry = new ExportEntry()
                            {
                                Hash40Hex = hashKeyFormatted
                            };
                            exportEntries.Add(hashKeyFormatted, exportKeyEntry);
                        }

                        exportKeyEntry.PRCFiles.Add(new ExportPRCFileEntry()
                        {
                            File = inputFileRelative,
                            IsKey = true,
                            Path = node.GetFullPath(),
                            Type = node.TypeKeyFormatted
                        });
                    }

                    //Value
                    if (node.IsHash40Value && (ulong)node.Value > 0)
                    {
                        var hash40Formatted = HashHelper.ToHash40((ulong)node.Value);
                        if (addedHashes.Contains(hash40Formatted))
                            continue;

                        if (!exportEntries.TryGetValue(hash40Formatted, out ExportEntry exportValueEntry))
                        {
                            exportValueEntry = new ExportEntry()
                            {
                                Hash40Hex = hash40Formatted
                            };
                            exportEntries.Add(hash40Formatted, exportValueEntry);
                        }

                        exportValueEntry.PRCFiles.Add(new ExportPRCFileEntry()
                        {
                            File = inputFileRelative,
                            IsKey = false,
                            Path = node.GetFullPath(),
                            Type = node.TypeKeyFormatted
                        });
                    }

                    addedHashes.Add(hashKeyFormatted);
                }
            }
        }

        private static void ProcessCFiles(Options o, Dictionary<string, HashInfo> dictHashInfo, Dictionary<string, ExportEntry> exportEntries, Dictionary<string, List<ExportFunctionEntry>> exportFunctions)
        {
            var filesC = Directory.GetFiles(o.InputCRootPath, "*.c", SearchOption.AllDirectories).ToList();

            //Blacklist for specific hashes known to be bad
            var blackList = new HashSet<string>();
            if (File.Exists("blacklist.txt"))
                blackList = File.ReadAllLines("blacklist.txt").ToHashSet();

            foreach (var fileC in filesC)
            {
                var file = Path.GetFileName(fileC);
                Console.WriteLine($"Processing '{fileC}'...");
                var fileContent = File.ReadAllLines(fileC);
                var functionDefinitions = new List<ExportFunctionEntry>();
                exportFunctions.Add(file, functionDefinitions);

                ExportFunctionEntry currentFunctionEntry = null;
                List<string> currentFunctionContent = null;
                int currentFunctionLine = 1;

                for (int i = 0; i < fileContent.Length; i++)
                {
                    currentFunctionLine++;

                    //Detect new function
                    if (!_functionExclude.Any(p => fileContent[i].StartsWith(p)) && fileContent[i].Length > 0)
                    {
                        if (currentFunctionEntry != null && (currentFunctionEntry.Hashes.Count > 0))
                        {
                            while (currentFunctionContent[^1].Trim() == string.Empty)
                                currentFunctionContent.RemoveAt(currentFunctionContent.Count - 1);
                            currentFunctionEntry.Content = string.Join("\r\n", currentFunctionContent);
                            functionDefinitions.Add(currentFunctionEntry);
                        }
                        currentFunctionEntry = new ExportFunctionEntry()
                        {
                            Function = fileContent[i]
                        };
                        currentFunctionContent = [];
                        currentFunctionLine = 1;
                    }

                    if (currentFunctionContent != null && !fileContent[i].StartsWith("//"))
                    {
                        currentFunctionContent.Add(fileContent[i]);
                    }

                    //Skip if no hash
                    if (!fileContent[i].Contains("0x"))
                        continue;

                    //Split words, seek for hashes
                    var words = fileContent[i].Split(_seekHexSeparators, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < words.Length; j++)
                    {
                        var word = words[j].ToLower();
                        bool suspiciousHex = false;

                        //Remove if part of blacklist
                        if (blackList.Contains(word))
                            continue;

                        //Sanity word check
                        if ((word.Length != 11 && word.Length != 12) || !word.StartsWith("0x")
                            || word == "0xffffffffff")
                            continue;

                        //Hexes looking weird
                        if (word.Contains("0000") || word.Contains("1111") || word.Contains("2222") || word.Contains("3333") ||
                            word.Contains("4444") || word.Contains("5555") || word.Contains("6666") || word.Contains("7777") ||
                            word.Contains("8888") || word.Contains("9999") || word.Contains("aaaa") || word.Contains("bbbb") ||
                            word.Contains("cccc") || word.Contains("dddd") || word.Contains("eeeee") || word.Contains("fffff") ||
                            word.Contains("10101") || word.Contains("01010"))
                            suspiciousHex = true;

                        //Words way too big are skipped (TBD?)
                        if (word.Length == 12 && (
                            word.StartsWith("0xf") || word.StartsWith("0xe") || word.StartsWith("0xd") || word.StartsWith("0xc") || word.StartsWith("0xb") || word.StartsWith("0xa") ||
                            word.StartsWith("0x9") || word.StartsWith("0x8") || word.StartsWith("0x7") || word.StartsWith("0x6") || word.StartsWith("0x5") || word.StartsWith("0x4")))
                            suspiciousHex = true;

                        //Sanitize Word
                        if (word.Length == 11)
                            word = word.Replace("0x", "0x0");

                        //Add to function hashes
                        if (!currentFunctionEntry.Hashes.Contains(word))
                            currentFunctionEntry.Hashes.Add(word);

                        //Solve the word, if possible
                        dictHashInfo.TryGetValue(word, out HashInfo label);
                        if (label == null)
                        {
                            if (j == 0)
                            {
                                suspiciousHex = true;
                            }
                            else if (j < words.Length - 1)
                            {
                                var nextWord = words[j + 1];
                                if (nextWord == "<" || nextWord == ">" || nextWord == "-" || nextWord == "+")
                                    suspiciousHex = true;
                            }
                            else
                            {
                                var previousWord = words[j - 1];
                                if (previousWord == "<" || previousWord == ">" || previousWord == "-" || previousWord == "+")
                                    suspiciousHex = true;
                            }
                        }

                        if (!exportEntries.TryGetValue(word, out ExportEntry exportEntry))
                        {
                            exportEntry = new ExportEntry()
                            {
                                Hash40Hex = word,
                                SuspiciousHex = label == null && suspiciousHex
                            };
                            exportEntries.Add(word, exportEntry);
                        }
                        else
                        {
                            if (!suspiciousHex)
                                exportEntry.SuspiciousHex = false;
                        }

                        var cFileEntry = exportEntry.CFiles.FirstOrDefault(p => p.File == file);
                        if (cFileEntry == null)
                        {
                            cFileEntry = new ExportCFileEntry()
                            {
                                File = file
                            };
                            exportEntry.CFiles.Add(cFileEntry);
                        }
                        cFileEntry.Instances.Add(new ExportCFileInstanceEntry()
                        {
                            FunctionId = functionDefinitions.Count,
                            FileLine = i,
                            FunctionLine = currentFunctionLine
                        });
                    }
                }

                //Last function
                if (currentFunctionEntry.Hashes.Count > 0)
                {
                    while (currentFunctionContent[^1].Trim() == string.Empty)
                        currentFunctionContent.RemoveAt(currentFunctionContent.Count - 1);
                    currentFunctionEntry.Content = string.Join("\r\n", currentFunctionContent);
                    functionDefinitions.Add(currentFunctionEntry);
                }
            }
        }

        private static void GenerateCSV(Options o, Dictionary<string, HashInfo> dictHashInfo, ExportContainer export)
        {
            var csvExport = new List<CSVEntry>();
            var exportEntries = export.ExportEntries;
            var functionsDefinitions = export.ExportFunctions;

            foreach (var exportEntry in export.ExportEntries)
            {
                var hash40 = exportEntry.Key;
                var entry = exportEntry.Value;
                var prc = entry.PRCFiles.FirstOrDefault();
                var c = entry.CFiles.FirstOrDefault();
                var functionInstance = c?.Instances.FirstOrDefault();
                var fileFunctions = functionInstance != null && functionsDefinitions.TryGetValue(c.File, out List<ExportFunctionEntry> fileFunctionsValue) ? fileFunctionsValue : [];
                var function = fileFunctions != null && functionInstance != null ? fileFunctions[functionInstance.FunctionId] : null;
                var functionName = function?.Function;
                var functionCode = function?.Content?.Split("\r\n")[functionInstance.FunctionLine]?.Trim();
                var relatedKnownHashes = function != null ? function.Hashes.Where(dictHashInfo.ContainsKey).Select(p => dictHashInfo[p].Label) : new List<string>();
                var relatedUnknownHashes = function != null ? function.Hashes.Where(p => !dictHashInfo.ContainsKey(p) && !exportEntries[p].SuspiciousHex) : new List<string>();
                var relatedSuspiciousHashes = function != null ? function.Hashes.Where(p => !dictHashInfo.ContainsKey(p) && exportEntries[p].SuspiciousHex) : new List<string>();

                dictHashInfo.TryGetValue(entry.Hash40Hex, out HashInfo label);
                var csvEntry = new CSVEntry()
                {
                    Hash = hash40,
                    Label = label?.Label,
                    LabelSources = label?.Sources != null ? string.Join(", ", label.Sources) : null,
                    PRCSources = string.Join(", ", entry.PRCFiles.Select(p => p.File).Distinct().OrderBy(p => p).Take(5)),
                    PRCType = prc != null && prc.IsKey ? "Key" : prc?.Type,
                    PRCFirstPath = entry.PRCFiles.FirstOrDefault()?.Path,
                    CSources = string.Join(", ", entry.CFiles.Select(p => p.File).Distinct().OrderBy(p => p).Take(5)),
                    CFirstFunction = functionName,
                    CFirstLine = functionInstance?.FileLine.ToString(),
                    CFirstCode = functionCode,
                    RelatedKnownHashes = string.Join(", ", relatedKnownHashes.OrderBy(p => p).Take(50)),
                    RelatedUnknownHashes = string.Join(", ", relatedUnknownHashes.OrderBy(p => p).Take(50)),
                    RelatedSuspiciousHashes = string.Join(", ", relatedSuspiciousHashes.OrderBy(p => p).Take(50)),
                    SuspiciousHash = entry.SuspiciousHex,
                };
                csvExport.Add(csvEntry);
            }

            if (!string.IsNullOrEmpty(o.OutputFileCSV))
            {
                GenerateCSV(o.OutputFileCSV, csvExport);

                var fileUncracked = $"{Path.GetFileNameWithoutExtension(o.OutputFileCSV)}_uncracked{Path.GetExtension(o.OutputFileCSV)}";
                GenerateCSV(fileUncracked, csvExport.Where(p => string.IsNullOrEmpty(p.Label)));

                var fileNRO = $"{Path.GetFileNameWithoutExtension(o.OutputFileCSV)}_nro{Path.GetExtension(o.OutputFileCSV)}";
                GenerateCSV(fileNRO, csvExport.Where(p => !string.IsNullOrEmpty(p.CSources)));

                var fileNROUncracked = $"{Path.GetFileNameWithoutExtension(o.OutputFileCSV)}_nro_uncracked{Path.GetExtension(o.OutputFileCSV)}";
                GenerateCSV(fileNROUncracked, csvExport.Where(p => string.IsNullOrEmpty(p.Label) && !string.IsNullOrEmpty(p.CSources)));

                var filePRC = $"{Path.GetFileNameWithoutExtension(o.OutputFileCSV)}_prc{Path.GetExtension(o.OutputFileCSV)}";
                GenerateCSV(filePRC, csvExport.Where(p => !string.IsNullOrEmpty(p.PRCSources)));
            }
        }

        private static void GenerateCSV(string input, IEnumerable<CSVEntry> csvExport)
        {
            Console.WriteLine($"Writing CSV '{input}'...");

            using var writer = new StreamWriter(input);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.WriteHeader<CSVEntry>();
            csv.NextRecord();
            foreach (var record in csvExport)
            {
                csv.WriteRecord(record);
                csv.NextRecord();
            }
        }
    }
}