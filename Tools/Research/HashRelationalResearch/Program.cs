using CommandLine;
using CsvHelper;
using HashCommon;
using HashCommon.Models;
using HashRelationalResearch.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace HashRelationalResearch
{
    class Program
    {
        private static readonly string[] _functionExclude = new string[] { "{", "}", "//", "#", " ", "LAB", "joined", "code" };
        private static readonly char[] _seekHexSeparators = new char[] { ' ', ',', ')', '(', '[', ']', '{', '}', ';', ':', 'U' };

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
            AppendToHashInfo(dictHashInfo, GetHashFile(o.InputParamLabelsFile, null, false), "ParamLabels");
            Console.WriteLine($"Loading MotionList '{o.InputFileMotionListLabels}'...");
            AppendToHashInfo(dictHashInfo, GetHashFile(o.InputFileMotionListLabels, new[] { '/', '.' }, true), "MotionList");
            Console.WriteLine($"Loading Paths '{o.InputFilePathHashes}'...");
            AppendToHashInfo(dictHashInfo, GetHashFile(o.InputFilePathHashes, new[] { '/' }, true), "Paths");
            Console.WriteLine($"Loading SoundInfo '{o.InputFileSoundLabelInfo}'...");
            AppendToHashInfo(dictHashInfo, GetHashFile(o.InputFileSoundLabelInfo, new[] { '/', '.' }, true), "SoundInfo");
            Console.WriteLine($"Loading SQB '{o.InputFileSQBLabels}'...");
            AppendToHashInfo(dictHashInfo, GetHashFile(o.InputFileSQBLabels, new[] { '/', '.' }, true), "SQB");
            Console.WriteLine($"Loading Effects '{o.InputFileEffectsLabels}'...");
            AppendEffectsFileToHashInfo(dictHashInfo, o.InputFileEffectsLabels, "Effects");

            //var file = JsonSerializer.Deserialize<ExportContainer>(File.ReadAllText(o.OutputFileJSON));
            //GenerateCSV(o, dictHashInfo, file);

            //Process PRC
            ProcessPRCFiles(o, dictHashInfo, exportEntries);

            //Process C Files
            var exportFunctions = new Dictionary<string, List<ExportFunctionEntry>>();
            ProcessCFiles(o, dictHashInfo, exportEntries, exportFunctions);

            //Generate Json
            Console.WriteLine($"Writing to JSON '{o.OutputFileJSON}'...");
            var container = new ExportContainer() { ExportEntries = exportEntries, ExportFunctions = exportFunctions };
            File.WriteAllText(o.OutputFileJSON, JsonSerializer.Serialize(new ExportContainer() { ExportEntries = exportEntries, ExportFunctions = exportFunctions }));

            //Generate CSV
            GenerateCSV(o, dictHashInfo, container);

            Console.WriteLine($"Found {exportEntries.Count} hashes");
            Console.WriteLine("DONE!");
            Console.ReadLine();
        }

        private static Dictionary<string, string> GetHashFile(string input, char[] splitChars, bool useCache = false)
        {
            var cachedFile = $"{input}.hash";
            if (File.Exists(cachedFile))
            {
                var cachedLines = File.ReadAllLines(input);
                return cachedLines.Select(p => p.Split(',', StringSplitOptions.RemoveEmptyEntries)).Where(p => p.Length > 1).ToDictionary(p => p[0], p => p[1]);
            }

            var hexes = new Dictionary<string, string>();
            var lines = File.ReadAllLines(input);
            foreach (var line in lines)
            {
                var hexString = HashHelper.ToHash40(line);
                if (!hexes.ContainsKey(hexString))
                    hexes.Add(hexString, line);

                var allWords = WordsParsing.SplitWords(line, splitChars);
                foreach (var word in allWords)
                {
                    var hexString2 = HashHelper.ToHash40(word);
                    if (!hexes.ContainsKey(hexString2))
                        hexes.Add(hexString2, word);
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
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csvEffects = csv.GetRecords<CSVEffect>().ToList();
                }
            }

            foreach (var csvEffect in csvEffects)
            {
                var value = csvEffect.Name.ToLower();
                var hexString = HashHelper.ToHash40(value);
                HashInfo hashInfo;
                if (!dictHashInfo.ContainsKey(hexString))
                {
                    hashInfo = new HashInfo()
                    {
                        Label = value,
                        Hash40Hex = hexString
                    };
                    dictHashInfo.Add(hexString, hashInfo);
                }
                else
                    hashInfo = dictHashInfo[hexString];

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
                HashInfo hashInfo;
                if (!dictHashInfo.ContainsKey(dictHashesEntry.Key))
                {
                    hashInfo = new HashInfo()
                    {
                        Label = dictHashesEntry.Value,
                        Hash40Hex = dictHashesEntry.Key
                    };
                    dictHashInfo.Add(dictHashesEntry.Key, hashInfo);
                }
                else
                    hashInfo = dictHashInfo[dictHashesEntry.Key];

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
                        var hashInfoKey = dictHashInfo.ContainsKey(hashKeyFormatted) ? dictHashInfo[hashKeyFormatted] : null;
                        ExportEntry exportKeyEntry;
                        if (!exportEntries.ContainsKey(hashKeyFormatted))
                        {
                            exportKeyEntry = new ExportEntry()
                            {
                                Hash40Hex = hashKeyFormatted,
                                Label = hashInfoKey
                            };
                            exportEntries.Add(hashKeyFormatted, exportKeyEntry);
                        }
                        else
                        {
                            exportKeyEntry = exportEntries[hashKeyFormatted];
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

                        var hashInfoValue = dictHashInfo.ContainsKey(hash40Formatted) ? dictHashInfo[hash40Formatted] : null;
                        ExportEntry exportValueEntry;
                        if (!exportEntries.ContainsKey(hash40Formatted))
                        {
                            exportValueEntry = new ExportEntry()
                            {
                                Hash40Hex = hash40Formatted,
                                Label = hashInfoValue
                            };
                            exportEntries.Add(hash40Formatted, exportValueEntry);
                        }
                        else
                        {
                            exportValueEntry = exportEntries[hash40Formatted];
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
                            while (currentFunctionContent[currentFunctionContent.Count - 1].Trim() == string.Empty)
                                currentFunctionContent.RemoveAt(currentFunctionContent.Count - 1);
                            currentFunctionEntry.Content = string.Join("\r\n", currentFunctionContent);
                            functionDefinitions.Add(currentFunctionEntry);
                        }
                        currentFunctionEntry = new ExportFunctionEntry()
                        {
                            Function = fileContent[i]
                        };
                        currentFunctionContent = new List<string>();
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
                        var label = dictHashInfo.ContainsKey(word) ? dictHashInfo[word] : null;
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

                        ExportEntry exportEntry;
                        if (!exportEntries.ContainsKey(word))
                        {
                            exportEntry = new ExportEntry()
                            {
                                Hash40Hex = word,
                                Label = label,
                                SuspiciousHex = label == null && suspiciousHex
                            };
                            exportEntries.Add(word, exportEntry);
                        }
                        else
                        {
                            exportEntry = exportEntries[word];
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
                            FunctionLine = currentFunctionLine,
                            LineCode = fileContent[i].Trim()
                        });
                    }
                }

                //Last function
                if (currentFunctionEntry.Hashes.Count > 0)
                {
                    while (currentFunctionContent[currentFunctionContent.Count - 1].Trim() == string.Empty)
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
                var fileFunctions = functionInstance != null && functionsDefinitions.ContainsKey(c.File) ? functionsDefinitions[c.File] : new List<ExportFunctionEntry>();
                var function = fileFunctions != null && functionInstance != null ? fileFunctions[functionInstance.FunctionId] : null;
                var functionName = function?.Function;
                var relatedKnownHashes = function != null ? function.Hashes.Where(p => dictHashInfo.ContainsKey(p)).Select(p => dictHashInfo[p].Label) : new List<string>();
                var relatedUnknownHashes = function != null ? function.Hashes.Where(p => !dictHashInfo.ContainsKey(p) && !exportEntries[p].SuspiciousHex) : new List<string>();
                var relatedSuspiciousHashes = function != null ? function.Hashes.Where(p => !dictHashInfo.ContainsKey(p) && exportEntries[p].SuspiciousHex) : new List<string>();

                var csvEntry = new CSVEntry()
                {
                    Hash = hash40,
                    Label = entry.Label?.Label,
                    LabelSources = entry.Label?.Sources != null ? string.Join(", ", entry.Label.Sources) : null,
                    PRCSources = string.Join(", ", entry.PRCFiles.Select(p => p.File).Distinct().Take(5)),
                    PRCType = prc != null && prc.IsKey ? "Key" : prc?.Type,
                    PRCFirstPath = entry.PRCFiles.FirstOrDefault()?.Path,
                    CSources = string.Join(", ", entry.CFiles.Select(p => p.File).Distinct().Take(5)),
                    CFirstFunction = functionName,
                    CFirstLine = functionInstance?.FileLine.ToString(),
                    CFirstCode = functionInstance?.LineCode,
                    RelatedKnownHashes = string.Join(", ", relatedKnownHashes),
                    RelatedUnknownHashes = string.Join(", ", relatedUnknownHashes),
                    RelatedSuspiciousHashes = string.Join(", ", relatedSuspiciousHashes),
                    SuspiciousHash = entry.SuspiciousHex,
                };
                csvExport.Add(csvEntry);
            }

            if (!string.IsNullOrEmpty(o.OutputFileCSV))
            {
                Console.WriteLine($"Writing to CSV '{o.OutputFileCSV}'...");
                using (var writer = new StreamWriter(o.OutputFileCSV))
                {
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteHeader<CSVEntry>();
                        csv.NextRecord();
                        foreach (var record in csvExport)
                        {
                            csv.WriteRecord(record);
                            csv.NextRecord();
                        }
                    }
                }

                var fileUncracked = $"{Path.GetFileNameWithoutExtension(o.OutputFileCSV)}_uncracked{Path.GetExtension(o.OutputFileCSV)}";
                Console.WriteLine($"Writing to CSV '{fileUncracked}'...");
                using (var writer = new StreamWriter(fileUncracked))
                {
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteHeader<CSVEntry>();
                        csv.NextRecord();
                        foreach (var record in csvExport.Where(p => string.IsNullOrEmpty(p.Label)))
                        {
                            csv.WriteRecord(record);
                            csv.NextRecord();
                        }
                    }
                }

                var fileNRO = $"{Path.GetFileNameWithoutExtension(o.OutputFileCSV)}_nro{Path.GetExtension(o.OutputFileCSV)}";
                Console.WriteLine($"Writing to CSV NRO only '{fileNRO}'...");
                using (var writer = new StreamWriter(fileNRO))
                {
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteHeader<CSVEntry>();
                        csv.NextRecord();
                        foreach (var record in csvExport.Where(p => !string.IsNullOrEmpty(p.CSources)))
                        {
                            csv.WriteRecord(record);
                            csv.NextRecord();
                        }
                    }
                }

                var fileNROUncracked = $"{Path.GetFileNameWithoutExtension(o.OutputFileCSV)}_nro_uncracked{Path.GetExtension(o.OutputFileCSV)}";
                Console.WriteLine($"Writing to CSV NRO Uncracked only '{fileNROUncracked}'...");
                using (var writer = new StreamWriter(fileNROUncracked))
                {
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteHeader<CSVEntry>();
                        csv.NextRecord();
                        foreach (var record in csvExport.Where(p => string.IsNullOrEmpty(p.Label) && !string.IsNullOrEmpty(p.CSources)))
                        {
                            csv.WriteRecord(record);
                            csv.NextRecord();
                        }
                    }
                }

                var filePRC = $"{Path.GetFileNameWithoutExtension(o.OutputFileCSV)}_prc{Path.GetExtension(o.OutputFileCSV)}";
                Console.WriteLine($"Writing to CSV PRC only '{filePRC}'...");
                using (var writer = new StreamWriter(filePRC))
                {
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteHeader<CSVEntry>();
                        csv.NextRecord();
                        foreach (var record in csvExport.Where(p => !string.IsNullOrEmpty(p.PRCSources)))
                        {
                            csv.WriteRecord(record);
                            csv.NextRecord();
                        }
                    }
                }
            }
        }
    }
}