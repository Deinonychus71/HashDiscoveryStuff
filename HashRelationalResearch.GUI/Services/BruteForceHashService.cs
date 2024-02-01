using BruteForceHash.Helpers;
using CommandLine;
using HashCommon;
using HashRelationalResearch.GUI.Helpers;
using HashRelationalResearch.GUI.Models;
using HashRelationalResearch.GUI.Services.Interfaces;
using HashRelationalResearch.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HashRelationalResearch.GUI.Services
{
    public class BruteForceHashService : IBruteForceHashService
    {
        private const string DEFAULT_ORDER_ALGORITHM = "fewer_words_first";
        private const string DEFAULT_DELIMITER = "_";
        private const bool DEFAULT_CONFIRM_END = true;

        private readonly IConfigurationService _configurationService;
        private readonly IHashDBService _hashDBService;
        private readonly IHbtFileService _hbtFileService;

        public string LastCommand { get; private set; } = string.Empty;

        public BruteForceHashService(IHashDBService hashDBService, IHbtFileService hbtFileService, IConfigurationService configurationService)
        {
            _configurationService = configurationService;
            _hashDBService = hashDBService;
            _hbtFileService = hbtFileService;
        }

        public bool StartProcess(HbtFile hbtFile, bool useHashCat)
        {
            if (string.IsNullOrEmpty(hbtFile?.HexValue))
                return false;

            var hash40 = hbtFile.HexValue;
            var hashEntry = _hashDBService.GetEntry(hash40);

            var useMethodDictionary = hbtFile.AttackType == AttackTypes.ATTACK_DICTIONARY;
            var useMethodHybrid = hbtFile.AttackType == AttackTypes.ATTACK_HYBRID;
            var useMethodCharacter = hbtFile.AttackType == AttackTypes.ATTACK_CHARACTER;

            var researchDictionaryContent = GenerateResearchDictionary(hashEntry);

            var options = new BruteForceHash.Options()
            {
                ConfirmEnd = DEFAULT_CONFIRM_END,
                PathHashCat = _configurationService.HashcatFilePath,
                HexValue = hash40,
                NbrThreads = hbtFile.NbrThreads,
                Method = hbtFile.AttackType,
                Verbose = hbtFile.Verbose,
                Prefix = hbtFile.Prefix,
                Suffix = hbtFile.Suffix,
            };

            //Dictionary & Hybrid
            if (useMethodDictionary || useMethodHybrid)
            {
                options.WordsLimit = hbtFile.WordFiltering.WordsLimit;
                options.Delimiter = DEFAULT_DELIMITER;

                options.Order = GetOrderAlgorithm(hbtFile.WordFiltering.Order);
                options.OrderLongerWordsFirst = GetOrderLongFirst(hbtFile.WordFiltering.Order);
                options.IncludeWordNotFirst = hbtFile.WordFiltering.IncludeWordNotFirst;
                options.IncludeWordNotLast = hbtFile.WordFiltering.IncludeWordNotLast;
                options.IncludeWord = hbtFile.WordFiltering.IncludeWordDict;
                options.IncludePatterns = hbtFile.WordFiltering.IncludePatterns;
                options.ExcludePatterns = hbtFile.WordFiltering.ExcludePatterns;

                options.MinDelimiters = hbtFile.SizeFiltering.MinDelimiters;
                options.MaxDelimiters = hbtFile.SizeFiltering.MaxDelimiters;
                options.MinWordLength = hbtFile.SizeFiltering.MinWordLength;
                options.MaxWordLength = hbtFile.SizeFiltering.MaxWordLength;
                options.MinOnes = hbtFile.SizeFiltering.MinOnes;
                options.MaxOnes = hbtFile.SizeFiltering.MaxOnes;
                options.MinTwos = hbtFile.SizeFiltering.MinTwos;
                options.MaxTwos = hbtFile.SizeFiltering.MaxTwos;
                options.MinThrees = hbtFile.SizeFiltering.MinThrees;
                options.MaxThrees = hbtFile.SizeFiltering.MaxThrees;
                options.MinFours = hbtFile.SizeFiltering.MinFours;
                options.MaxFours = hbtFile.SizeFiltering.MaxFours;
                options.AtLeastAboveChars = hbtFile.SizeFiltering.AtLeastNbrGteCharacters;
                options.AtLeastAboveWords = hbtFile.SizeFiltering.AtLeastNbrGteWords;
                options.AtLeastUnderChars = hbtFile.SizeFiltering.AtLeastNbrLteCharacters;
                options.AtLeastUnderWords = hbtFile.SizeFiltering.AtLeastNbrLteWords;
                options.AtMostAboveChars = hbtFile.SizeFiltering.AtMostNbrGteCharacters;
                options.AtMostAboveWords = hbtFile.SizeFiltering.AtMostNbrGteWords;
                options.AtMostUnderChars = hbtFile.SizeFiltering.AtMostNbrLteCharacters;
                options.AtMostUnderWords = hbtFile.SizeFiltering.AtMostNbrLteWords;
            }

            if (hbtFile.AdvancedAttack.UseDictionaryAdvanced && (useMethodDictionary || (useMethodHybrid && !hbtFile.HybridAttack.IgnoreSizeFilters)))
            {
                options.MinWordsLimit = hbtFile.AdvancedAttack.MinWordsLimit;
                options.MinConcatenatedWords = hbtFile.AdvancedAttack.MinConcatenatedWords;
                options.MaxConcatenatedWords = hbtFile.AdvancedAttack.MaxConcatenatedWords;
                options.MinConsecutiveConcatenation = hbtFile.AdvancedAttack.MinConsecutiveConcatenation;
                options.MaxConsecutiveConcatenation = hbtFile.AdvancedAttack.MaxConsecutiveConcatenation;
                options.MaxConsecutiveOnes = hbtFile.AdvancedAttack.MaxConsecutiveOnes;
                options.ConcatenateFirstTwoWords = hbtFile.AdvancedAttack.ConcatenateFirstTwoWords;
                options.ConcatenateLastTwoWords = hbtFile.AdvancedAttack.ConcatenateLastTwoWords;
            }

            //Dictionary Only
            if (useMethodDictionary)
            {
                options.EnableDynamicPrefixCache = hbtFile.DictionaryAttack.DictionaryMain.MainCacheDynamicPrefix;
                options.EnableDynamicSuffixCache = hbtFile.DictionaryAttack.DictionaryMain.MainCacheDynamicSuffix;

                options.TyposEnableSkipDoubleLetter = hbtFile.Typos.TyposEnableSkipDoubleLetter;
                options.TyposEnableSkipLetter = hbtFile.Typos.TyposEnableSkipLetter;
                options.TyposEnableSkipLetter = hbtFile.Typos.TyposEnableSkipLetter;
                options.TyposEnableExtraLetter = hbtFile.Typos.TyposEnableExtraLetter;
                options.TyposEnableWrongLetter = hbtFile.Typos.TyposEnableWrongLetter;
                options.TyposEnableReverseLetter = hbtFile.Typos.TyposEnableReverseLetter;
                options.TyposEnableAppendLetters = hbtFile.Typos.TyposEnableAppendLetters.Trim();
                options.TyposEnableLetterSwap = hbtFile.Typos.TyposEnableLetterSwap.Trim();

                //Main Dictionary
                options.Dictionaries = GetAllDictionaries(hbtFile, hbtFile.DictionaryAttack.DictionaryMain, researchDictionaryContent);
                options.DictionariesCustom = GetCustomDictionary(hbtFile, hbtFile.DictionaryAttack.DictionaryMain, "[Main][Custom]", researchDictionaryContent);
                options.DictionariesExclude = GetExcludeDictionary(hbtFile, hbtFile.DictionaryAttack.DictionaryMain, "[Main][Exclude]");
                options.DictionariesExcludePartialWords = hbtFile.DictionaryAttack.DictionaryMain.ExcludePartialWords;
                options.DictionaryFilterFirstFrom = hbtFile.DictionaryAttack.DictionaryMain.MainFilterFirstFrom;
                options.DictionaryFilterFirstTo = hbtFile.DictionaryAttack.DictionaryMain.MainFilterFirstTo;
                options.DictionariesSkipDigits = hbtFile.DictionaryAttack.DictionaryMain.SkipDigits;
                options.DictionariesSkipSpecials = hbtFile.DictionaryAttack.DictionaryMain.SkipSpecials;
                options.DictionariesForceLowercase = hbtFile.DictionaryAttack.DictionaryMain.ForceLowercase;
                options.DictionariesAddTypos = hbtFile.DictionaryAttack.DictionaryMain.AddTypos;
                options.DictionariesReverseOrder = hbtFile.DictionaryAttack.DictionaryMain.ReverseOrder;
                options.DictionariesCustomSkipDigits = hbtFile.DictionaryAttack.DictionaryMain.CustomWordsSkipDigits;
                options.DictionariesCustomSkipSpecials = hbtFile.DictionaryAttack.DictionaryMain.CustomWordsSkipSpecials;
                options.DictionariesCustomForceLowercase = hbtFile.DictionaryAttack.DictionaryMain.CustomWordsForceLowercase;
                options.DictionariesCustomAddTypos = hbtFile.DictionaryAttack.DictionaryMain.CustomWordsAddTypos;
                options.DictionariesCustomMinWordsHash = hbtFile.DictionaryAttack.DictionaryMain.MainCustomWordsMinimumInHash;
                options.DictionariesCustomMinWordsHashUseTypos = hbtFile.DictionaryAttack.DictionaryMain.MainCustomWordsMinimumInHashUseTypos;

                //First Dictionary
                options.DictionariesFirstWord = GetAllDictionaries(hbtFile, hbtFile.DictionaryAttack.DictionaryFirstWord, researchDictionaryContent);
                options.DictionariesFirstWordCustom = GetCustomDictionary(hbtFile, hbtFile.DictionaryAttack.DictionaryFirstWord, "[1st][Custom]", researchDictionaryContent);
                options.DictionariesFirstWordExclude = GetExcludeDictionary(hbtFile, hbtFile.DictionaryAttack.DictionaryFirstWord, "[1st][Exclude]");
                options.DictionariesFirstWordExcludePartialWords = hbtFile.DictionaryAttack.DictionaryFirstWord.ExcludePartialWords;
                options.DictionariesFirstSkipDigits = hbtFile.DictionaryAttack.DictionaryFirstWord.SkipDigits;
                options.DictionariesFirstSkipSpecials = hbtFile.DictionaryAttack.DictionaryFirstWord.SkipSpecials;
                options.DictionariesFirstForceLowercase = hbtFile.DictionaryAttack.DictionaryFirstWord.ForceLowercase;
                options.DictionariesFirstAddTypos = hbtFile.DictionaryAttack.DictionaryFirstWord.AddTypos;
                options.DictionariesFirstReverseOrder = hbtFile.DictionaryAttack.DictionaryFirstWord.ReverseOrder;
                options.DictionariesFirstCustomSkipDigits = hbtFile.DictionaryAttack.DictionaryFirstWord.CustomWordsSkipDigits;
                options.DictionariesFirstCustomSkipSpecials = hbtFile.DictionaryAttack.DictionaryFirstWord.CustomWordsSkipSpecials;
                options.DictionariesFirstCustomForceLowercase = hbtFile.DictionaryAttack.DictionaryFirstWord.CustomWordsForceLowercase;
                options.DictionariesFirstCustomAddTypos = hbtFile.DictionaryAttack.DictionaryFirstWord.CustomWordsAddTypos;

                //Last Dictionary
                options.DictionariesLastWord = GetAllDictionaries(hbtFile, hbtFile.DictionaryAttack.DictionaryLastWord, researchDictionaryContent);
                options.DictionariesLastWordCustom = GetCustomDictionary(hbtFile, hbtFile.DictionaryAttack.DictionaryLastWord, "[Last][Custom]", researchDictionaryContent);
                options.DictionariesLastWordExclude = GetExcludeDictionary(hbtFile, hbtFile.DictionaryAttack.DictionaryLastWord, "[Last][Exclude]");
                options.DictionariesLastWordExcludePartialWords = hbtFile.DictionaryAttack.DictionaryLastWord.ExcludePartialWords;
                options.DictionariesLastSkipDigits = hbtFile.DictionaryAttack.DictionaryLastWord.SkipDigits;
                options.DictionariesLastSkipSpecials = hbtFile.DictionaryAttack.DictionaryLastWord.SkipSpecials;
                options.DictionariesLastForceLowercase = hbtFile.DictionaryAttack.DictionaryLastWord.ForceLowercase;
                options.DictionariesLastAddTypos = hbtFile.DictionaryAttack.DictionaryLastWord.AddTypos;
                options.DictionariesLastReverseOrder = hbtFile.DictionaryAttack.DictionaryLastWord.ReverseOrder;
                options.DictionariesLastCustomSkipDigits = hbtFile.DictionaryAttack.DictionaryLastWord.CustomWordsSkipDigits;
                options.DictionariesLastCustomSkipSpecials = hbtFile.DictionaryAttack.DictionaryLastWord.CustomWordsSkipSpecials;
                options.DictionariesLastCustomForceLowercase = hbtFile.DictionaryAttack.DictionaryLastWord.CustomWordsForceLowercase;
                options.DictionariesLastCustomAddTypos = hbtFile.DictionaryAttack.DictionaryLastWord.CustomWordsAddTypos;
            }

            //Character only
            if (useMethodCharacter)
            {
                if(!useHashCat)
                    options.UseUTF8 = hbtFile.CharacterAttack.EnableUtf8;
                options.UseHashcat = useHashCat;

                var selectedCharsets = Charsets.GetCharsetList().Where(p => hbtFile.CharacterAttack.Charsets.Contains(p.Name));
                options.ValidChars = Charsets.GetAllValidChars(hbtFile.CharacterAttack.ValidChars, selectedCharsets);
                options.ValidStartingChars = Charsets.GetAllValidChars(hbtFile.CharacterAttack.ValidStartingChars, selectedCharsets);
                options.IncludeWord = hbtFile.CharacterAttack.IncludeWord;
                options.StartPosition = hbtFile.CharacterAttack.StartPosition;
                options.EndPosition = hbtFile.CharacterAttack.EndPosition;
            }

            //Hybrid only
            if (useMethodHybrid)
            {
                options.UseHashcat = useHashCat;

                var selectedCharsets = Charsets.GetCharsetList().Where(p => hbtFile.HybridAttack.Charsets.Contains(p.Name));
                options.ValidChars = Charsets.GetAllValidChars(hbtFile.HybridAttack.ValidChars, selectedCharsets);
                options.ValidStartingChars = Charsets.GetAllValidChars(hbtFile.HybridAttack.ValidStartingChars, selectedCharsets);

                options.HybridWordsHash = hbtFile.HybridAttack.WordsInHash;
                options.HybridMinCharacters = hbtFile.HybridAttack.BruteforceMinChars;
                options.HybridMaxCharacters = hbtFile.HybridAttack.BruteforceMaxChars;
                options.HybridMinCharHashcatThreshold = hbtFile.HybridAttack.MinCharHashcatThreshold;
                options.HybridIgnoreSizeFilters = hbtFile.HybridAttack.IgnoreSizeFilters;

                options.HybridDictionary = GetHybridDictionary(hbtFile, hbtFile.HybridAttack.Dictionary, "[Main][Hybrid]", researchDictionaryContent);
                options.HybridDictionaryFirstWord = GetHybridDictionary(hbtFile, hbtFile.HybridAttack.DictionaryFirstWord, "[1st][Hybrid]", researchDictionaryContent);
                options.HybridDictionaryLastWord = GetHybridDictionary(hbtFile, hbtFile.HybridAttack.DictionaryLastWord, "[Last][Hybrid]", researchDictionaryContent);
            }

            //Start Bruteforce
            using var process = new Process();
            process.StartInfo.FileName = "BruteForceHash.exe";
            process.StartInfo.Arguments = FormatCommandLineWithBugHandling(options);
            LastCommand = process.StartInfo.Arguments;

            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.WaitForExit();
            process.Close();

            return true;
        }

        private static string? FormatCommandLineWithBugHandling(BruteForceHash.Options options)
        {
            var args = Parser.Default.FormatCommandLine(options);
            var props = typeof(BruteForceHash.Options).GetProperties();
            foreach (var prop in props)
            {
                if (prop.PropertyType == typeof(int))
                {
                    var attrs = prop.GetCustomAttributes(true);
                    foreach (object attr in attrs)
                    {
                        if (attr is OptionAttribute attribute)
                        {
                            var longName = $"--{attribute.LongName}";
                            if (!args.Contains(longName) && (int)attribute.Default != 0)
                            {
                                args += $" {longName} 0";
                            }
                        }
                    }
                }
            }

            return args;
        }

        private string? GetAllDictionaries(HbtFile hbtFile, HbtFileDictionary dictionary, IEnumerable<string> researchDictionaryContent)
        {
            if (dictionary.UseDictionary)
            {
                var dictionaries = new List<string>();
                dictionaries.AddRange(dictionary.Words);

                if (dictionary.UseResearchWords)
                {
                    var researchDictionaryPath = SaveCustomDictionary(hbtFile, $"[Research]", researchDictionaryContent);
                    if (researchDictionaryPath != null)
                        dictionaries.Add(researchDictionaryPath);
                }
                return string.Join(';', dictionaries);
            }
            return null;
        }

        private string? GetCustomDictionary(HbtFile hbtFile, HbtFileDictionary dictionary, string dictName, IEnumerable<string> researchDictionary)
        {
            if (dictionary.UseCustomWords)
            {
                var dictionaries = new List<string>();
                dictionaries.AddRange(GenerateCustomDictionary(dictionary.CustomWords));

                if (dictionary.CustomWordsUseResearchWords)
                    dictionaries.AddRange(researchDictionary);

                return SaveCustomDictionary(hbtFile, dictName, dictionaries);
            }
            return null;
        }

        private string? GetHybridDictionary(HbtFile hbtFile, HbtFileHybridDictionary dictionary, string dictName, IEnumerable<string> researchDictionary)
        {
            if (dictionary.UseDictionary)
            {
                var dictionaries = new List<string>();
                dictionaries.AddRange(GenerateCustomDictionary(dictionary.Words));
                if (dictionary.UseResearchWords)
                    dictionaries.AddRange(researchDictionary);

                return SaveCustomDictionary(hbtFile, dictName, dictionaries);
            }
            return null;
        }

        private string? GetExcludeDictionary(HbtFile hbtFile, HbtFileDictionary dictionary, string dictName)
        {
            if (dictionary.UseExcludeWords)
            {
                return SaveCustomDictionary(hbtFile, dictName, dictionary.ExcludeWords);
            }
            return null;
        }

        private string? SaveCustomDictionary(HbtFile hbtFile, string dictionaryName, IEnumerable<string> dictionaryContent)
        {
            var folderPath = _hbtFileService.GetQuickDirectoryPath(hbtFile, true);
            if (Directory.Exists(folderPath))
            {
                var filePath = Path.Combine(folderPath, $"[{hbtFile.HexValue}]{dictionaryName}.dic");
                File.WriteAllLines(filePath, dictionaryContent);
                return filePath;
            }
            return null;
        }

        private IEnumerable<string> GenerateResearchDictionary(ExportEntry? hashEntry)
        {
            var word = new List<string>();

            if (hashEntry != null)
            {
                //Create dictionary based on CFiles
                foreach (var cFile in hashEntry.CFiles)
                {
                    var functionIds = cFile.Instances.Select(p => p.FunctionId);
                    var functionHashes = _hashDBService.GetFunctions(cFile.File, functionIds);
                    if (functionHashes != null)
                    {
                        var hashes = functionHashes.SelectMany(p => p.Hashes);
                        if (hashes != null)
                        {
                            foreach (var hash40 in hashes)
                            {
                                var label = _hashDBService.GetLabel(hash40);
                                if (!string.IsNullOrEmpty(label))
                                {
                                    word.AddRange(WordsParsing.SplitWords(label));
                                }
                            }
                        }
                    }
                }

                //Create dictionary based on PRC
                foreach (var prc in hashEntry.PRCFiles)
                {
                    var entriesWithSameFilePath = _hashDBService.GetEntriesByPRCFile(prc.File);
                    if (entriesWithSameFilePath != null)
                    {
                        foreach (var prcEntry in entriesWithSameFilePath)
                        {
                            var label = _hashDBService.GetLabel(prcEntry.Hash40Hex);
                            if (!string.IsNullOrEmpty(label))
                            {
                                word.AddRange(WordsParsing.SplitWords(label));
                            }
                        }
                    }
                }


            }

            return word.Distinct().OrderBy(p => p);
        }

        private static IEnumerable<string> GenerateCustomDictionary(List<string> words)
        {
            return words.Distinct().OrderBy(p => p);
        }

        private static string GetOrderAlgorithm(string order)
        {
            var orderAlgorithm = order.Split("|");
            if (orderAlgorithm.Length == 2)
                return orderAlgorithm[0];
            return DEFAULT_ORDER_ALGORITHM;
        }

        private static bool GetOrderLongFirst(string order)
        {
            var orderAlgorithm = order.Split("|");
            if (orderAlgorithm.Length == 2)
                return orderAlgorithm[1] == "long";
            return true;
        }
    }
}
