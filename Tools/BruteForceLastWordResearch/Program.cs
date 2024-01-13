using BruteForceLastWordResearch.BruteForceHashing;
using CommandLine;
using CsvHelper;
using HashCommon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceLastWordResearch
{
    /// <summary>
    /// Split the paramlabel words using different value types to make dictionary. Require prc/stprm/stdat files.
    /// </summary>
    public class Program
    {
        private readonly static string[] _numericTypes = new string[] { "byte", "float", "int", "sbyte", "short", "uint", "ushort" };
        private readonly static string _inlineType = "Inline";
        private readonly static string _inlinePath = "Inline";

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed((o) =>
            {
                RunProgram(o);
            });
        }

        public static void RunProgram(Options o)
        {
            var isPathMode = string.IsNullOrEmpty(o.InputInlineHashes);

            Console.WriteLine($"----------------------------------------------");
            Console.WriteLine($"BruteForce LastWord Research");
            Console.WriteLine($"----------------------------------------------");
            if (isPathMode)
            {
                Console.WriteLine($"Source file for uncracked hashes: {o.InputUncrackedHashesGrouped}");
                Console.WriteLine($"Source dictionary for numeric last words: {o.InputLastWordsDictionaryNumeric}");
                Console.WriteLine($"Source dictionary for other last words: {o.InputLastWordsDictionaryOther}");
                Console.WriteLine($"Output Folder: {o.OutputPath}");
                Console.WriteLine($"Include Filter Path: {o.IncludeFilterPath}");
                Console.WriteLine($"Exclude Filter Path: {o.ExcludeFilterPath}");
                Console.WriteLine($"Accepted Types: {o.AcceptedTypes}");
            }
            else
                Console.WriteLine($"Hashes to test: {o.InputInlineHashes}");
            Console.WriteLine($"Search Size Minimum: {o.SearchSizeMinimum}");
            Console.WriteLine($"Search Size Maximum: {o.SearchSizeMaximum}");
            Console.WriteLine($"----------------------------------------------");
            Console.WriteLine($"Running with {o.NbrThreads} threads.");
            Console.WriteLine($"----------------------------------------------");

            if (isPathMode && !File.Exists(o.InputUncrackedHashesGrouped))
            {
                Logger.LogError($"File '{o.InputUncrackedHashesGrouped}' does not exist");
                return;
            }
            if (isPathMode && !File.Exists(o.InputLastWordsDictionaryNumeric))
            {
                Logger.LogError($"File '{o.InputLastWordsDictionaryNumeric}' does not exist");
                return;
            }
            if (isPathMode && !File.Exists(o.InputLastWordsDictionaryOther))
            {
                Logger.LogError($"File '{o.InputLastWordsDictionaryOther}' does not exist");
                return;
            }
            if (!isPathMode && !File.Exists(o.InputLastWordsDictionaryInline))
            {
                Logger.LogError($"File '{o.InputLastWordsDictionaryInline}' does not exist");
                return;
            }
            Directory.CreateDirectory(o.OutputPath);

            var excludeFilters = o.ExcludeFilterPath?.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToList();
            excludeFilters ??= new List<string>();
            var includeFilters = o.IncludeFilterPath?.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToList();
            includeFilters ??= new List<string>();
            var acceptedTypes = o.AcceptedTypes?.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToList();
            acceptedTypes ??= new List<string>();
            acceptedTypes.Add(_inlineType);

            //Read CSV
            IEnumerable<CsvEntryUncracked> csvEntries;
            if (isPathMode)
            {
                csvEntries = GetCsvEntries(o.InputUncrackedHashesGrouped);
                foreach (var item in csvEntries)
                    item.FilePaths = item.FilePaths.Split("|", StringSplitOptions.RemoveEmptyEntries)?.FirstOrDefault()?.Trim();
            }
            else
            {
                csvEntries = o.InputInlineHashes.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(p => new CsvEntryUncracked()
                {
                    KeyOrValue = null,
                    FilePaths = _inlinePath,
                    Hex = p.Trim(),
                    Type = _inlineType
                });
            }

            //Read LastWord Dictionary
            string[] lastWordsNumericDic = Array.Empty<string>();
            string[] lastWordsOtherDic = Array.Empty<string>();
            string[] lastWordsInlineDic = Array.Empty<string>();
            if (isPathMode)
            {
                lastWordsNumericDic = File.ReadAllLines(o.InputLastWordsDictionaryNumeric).Distinct().OrderBy(p => p).ToArray();
                lastWordsOtherDic = File.ReadAllLines(o.InputLastWordsDictionaryOther).Distinct().OrderBy(p => p).ToArray();
            }
            else
                lastWordsInlineDic = File.ReadAllLines(o.InputLastWordsDictionaryInline).Distinct().OrderBy(p => p).ToArray();

            //Configure BruteForceCharacter Helper
            BruteForceCharacterHelper.SetValidChars("01234567890abcdefghijklmnopqrstuvwxyz_");
            BruteForceCharacterHelper.SetValidStartChars("01234567890abcdefghijklmnopqrstuvwxyz_");

            foreach (var filePathGroup in csvEntries.GroupBy(p => p.FilePaths).Where(p => p.Count() > 1).OrderBy(p => p.Count()))
            {
                if (isPathMode)
                {
                    if (includeFilters.Count > 0 && !includeFilters.Any(f => filePathGroup.Key.StartsWith(f)))
                        continue;
                    if (excludeFilters.Any(f => filePathGroup.Key.StartsWith(f)))
                        continue;
                }

                //Search one file
                var filePath = filePathGroup.Key;
                var savedPathFile = Path.Combine(o.OutputPath, filePath.Trim('/').Replace('/', Path.DirectorySeparatorChar));
                var savedPathFileCsv = savedPathFile + ".csv";
                var savedPathFileTxt = savedPathFile + "_noresult.txt";

                if (isPathMode && (File.Exists(savedPathFileCsv) || File.Exists(savedPathFileTxt)))
                    continue;

                Logger.LogInformation($"{filePathGroup.Key}: Processing {filePathGroup.Count()} hashes...");

                var dictionaryFalsePositives = new Dictionary<string, CorrelationEntry>();

                foreach (var hexEntry in filePathGroup)
                {
                    if (!acceptedTypes.Contains(hexEntry.Type, StringComparer.OrdinalIgnoreCase))
                        continue;

                    Logger.LogInformation($"{filePathGroup.Key}: Processing hash {hexEntry.Hex} ({hexEntry.Type})...");

                    string[] lastWordsDic;
                    if(hexEntry.Type == _inlineType)
                        lastWordsDic = lastWordsInlineDic;
                    else if (_numericTypes.Contains(hexEntry.Type))
                        lastWordsDic = lastWordsNumericDic;
                    else
                        lastWordsDic = lastWordsOtherDic;

                    if (lastWordsDic.Length == 0)
                        continue;

                    var split = hexEntry.Hex.Split("x".ToCharArray());
                    var lengthStr = split[1][..2];
                    var valueStr = split[1][2..];
                    var hexLength = Convert.ToInt32(lengthStr, 16);
                    var hexToFind = Convert.ToUInt32(valueStr, 16);

                    var lineIndex = 0;
                    foreach (var lastWord in lastWordsDic)
                    {
                        Logger.LogInformation($"{filePathGroup.Key}: Testing last word {lastWord} ({lineIndex + 1}/{lastWordsDic.Count()})", lineIndex != 0);
                        lineIndex++;

                        if (lastWord.Length + o.SearchSizeMinimum > hexLength)
                            continue;

                        if (hexLength - lastWord.Length > o.SearchSizeMaximum)
                            continue;

                        var falsePositiveFound = BruteForceCharacterHelper.RunCharacterBruteForce(hexToFind, hexLength, suffix: lastWord, nbrThreads: o.NbrThreads, shouldInterruptAtFirstResult: true);
                        if (falsePositiveFound != null)
                        {
                            var hexValue = Encoding.UTF8.GetString(falsePositiveFound.Value);
                            if (!dictionaryFalsePositives.ContainsKey(hexValue))
                            {
                                var correlationEntry = new CorrelationEntry()
                                {
                                    HexCorrelated = hexValue,
                                    FilePaths = filePath,
                                    Type = hexEntry.Type,
                                    CorrelatedHashes = new List<string>() { hexEntry.Hex },
                                    CorrelatedValues = new List<string>() { falsePositiveFound.ToString() }
                                };
                                dictionaryFalsePositives.Add(hexValue, correlationEntry);
                            }
                            else
                            {
                                var correlationEntry = dictionaryFalsePositives[hexValue];
                                correlationEntry.CorrelatedHashes.Add(hexEntry.Hex);
                                correlationEntry.CorrelatedValues.Add(falsePositiveFound.ToString());
                            }
                        }
                    }
                    Logger.ClearPreviousConsoleLine();
                }

                //Export
                Directory.CreateDirectory(Path.GetDirectoryName(savedPathFileCsv));

                var correlatedFlatted = dictionaryFalsePositives.Values.SelectMany(p =>
                {
                    if (p.CorrelatedValues.Count > 1)
                    {
                        var output = new List<CsvEntryCorrelated>();
                        for (int i = 0; i < p.CorrelatedValues.Count; i++)
                        {
                            output.Add(new CsvEntryCorrelated()
                            {
                                HexCorrelated = p.HexCorrelated,
                                FilePaths = p.FilePaths,
                                Type = p.Type,
                                CorrelatedHash = p.CorrelatedHashes[i],
                                CorrelatedValue = p.CorrelatedValues[i]
                            });
                        }
                        return output;
                    }
                    else
                        return new List<CsvEntryCorrelated>();
                }).OrderBy(p => p.HexCorrelated).ToList();

                if (isPathMode)
                {
                    if (correlatedFlatted.Any())
                    {
                        using (var writer = new StreamWriter(savedPathFileCsv))
                        {
                            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                            {
                                csv.WriteHeader<CsvEntryCorrelated>();
                                csv.NextRecord();
                                csv.WriteRecords(correlatedFlatted);
                            }
                        }
                    }
                    else
                        File.WriteAllText(savedPathFileTxt, "no results");
                }
                else
                {
                    if (correlatedFlatted.Any())
                    {
                        Logger.LogSuccess($"{filePathGroup.Key}: Results");
                        foreach (var correlatedFlattedItem in correlatedFlatted)
                            Logger.LogSuccess($"{filePathGroup.Key}: {correlatedFlattedItem.CorrelatedHash} - {correlatedFlattedItem.CorrelatedValue}");
                    }
                    else
                    {
                        Logger.LogInformation($"{filePathGroup.Key}: No result :(");
                    }
                }
            }

            Logger.LogSuccess("DONE");
            Logger.LogInformation("Please 'Enter' to exit.");
            Console.ReadLine();
        }

        private static IEnumerable<CsvEntryUncracked> GetCsvEntries(string csvPath)
        {
            using var reader = new StreamReader(csvPath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<CsvEntryUncracked>().ToList();
        }
    }
}
