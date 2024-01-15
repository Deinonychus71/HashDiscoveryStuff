using CommandLine;
using HashCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HashCrackDictionaryGen
{
    class Program
    {
        private static int[] _listByHits = new int[] { 2, 3, 4, 5, 10, 15, 20, 50 };
        private readonly static Regex _regOnlyDigits = new Regex(@"^[0-9]+$", RegexOptions.Compiled);

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed((o) =>
            {
                RunProgram(o);
            });
        }

        public static void RunProgram(Options o)
        {
            //Get language dictionaries
            var dictFileEnglish = o.EnglishDictionary;
            var dictFileJapanese = o.JapaneseDictionary;
            var allEnglishWords = File.Exists(dictFileEnglish) ? File.ReadAllLines(dictFileEnglish).Select(p => p.ToLower()).Distinct().ToHashSet() : new HashSet<string>();
            var allJapaneseWords = File.Exists(dictFileJapanese) ? File.ReadAllLines(dictFileJapanese).Select(p => p.ToLower()).Distinct().ToHashSet() : new HashSet<string>();
            if (!allEnglishWords.Any())
                Console.WriteLine($"No English dictionary found. Please add a dictionary '{dictFileEnglish}'");
            if (!allJapaneseWords.Any())
                Console.WriteLine($"No English dictionary found. Please add a dictionary '{dictFileJapanese}'");

            //----------------- Smash Ultimate -----------------
            //ParamLabel
            var pathParamLabels = Path.Combine("Dictionaries", "SmashUltimate", "ParamLabels");
            GenerateSmashParamLabelDictionaries(o, pathParamLabels, allEnglishWords, allJapaneseWords);

            //Path
            var pathPath = Path.Combine("Dictionaries", "SmashUltimate", "Path");
            GenerateSmashPathDictionaries(o, pathPath, allEnglishWords, allJapaneseWords);

            //Key-Value
            var pathParamLabelsKeyValue = Path.Combine(pathParamLabels, "Key-Value");
            GenerateSmashKeyValueDictionary(o, pathParamLabelsKeyValue);

            //MSBT
            var pathMSBT = Path.Combine("Dictionaries", "SmashUltimate", "MSBT");
            GenerateMSBTValueDictionary(o, pathMSBT);

            //----------------- Smash Wii U -----------------
            var pathSmashWiiU = Path.Combine("Dictionaries", "SmashWiiU");
            GenerateSmashWiiUDictionaries(o, pathSmashWiiU, allEnglishWords, allJapaneseWords);
        }

        static void GenerateSmashParamLabelDictionaries(Options o, string pathParamLabels, HashSet<string> allEnglishWords, HashSet<string> allJapaneseWords)
        {
            var folderSpecialized = Path.Combine(pathParamLabels, "Specialized");
            var folderLanguage = Path.Combine(pathParamLabels, "Language");
            var folderByHits = Path.Combine(pathParamLabels, "ByHits");

            var allHashesPM = File.ReadAllLines(o.InputParamLabelsFile).Where(p => p.Contains(',')).Select(p => p.Split(',')[1]).Where(p => !string.IsNullOrEmpty(p)).ToList();
            var allHashesCV = File.ReadAllLines(o.InputFileConstValueTableFile).Where(p => p.Contains(',')).Select(p => p.Split(',')[1]).Where(p => !string.IsNullOrEmpty(p)).Select(p => p.ToLower());
            allHashesPM.AddRange(allHashesCV);

            IEnumerable<string> allHashes = allHashesPM.Distinct();
            var allWords = WordsParsing.GetAllWords(allHashes);

            //Export Full Dictionary
            ExportDictionary(pathParamLabels, "[SmashUltimate][ParamLabels]Full", allWords);

            //Export Digits Only
            var numericHashes = allWords.Where(p => _regOnlyDigits.IsMatch(p));
            ExportDictionary(folderSpecialized, "[SmashUltimate][ParamLabels][Specialized]Digits_Only", numericHashes);

            //Remove exclusively digits hashes
            allHashes = allHashes.Where(p => !_regOnlyDigits.IsMatch(p));

            //Nouns
            var fightersHashes = allHashes.Where(p => p.StartsWith("fighter_kind_")).Select(p => p.Replace("fighter_kind_", string.Empty));
            var fighters2Hashes = allHashes.Where(p => p.StartsWith("ui_profile_ft_")).Select(p => p.Replace("ui_profile_ft_", string.Empty));
            var fighters3Hashes = allHashes.Where(p => p.StartsWith("ui_profile_fe_")).Select(p => p.Replace("ui_profile_fe_", string.Empty));
            var fighters4Hashes = allHashes.Where(p => p.StartsWith("ui_chara_")).Select(p => p.Replace("ui_chara_", string.Empty));
            var fighters5Hashes = allHashes.Where(p => p.StartsWith("ui_anniv_chara_")).Select(p => p.Replace("ui_anniv_chara_", string.Empty));
            var fightersList = fightersHashes.ToList();
            fightersList.AddRange(fighters2Hashes);
            fightersList.AddRange(fighters3Hashes);
            fightersList.AddRange(fighters4Hashes);
            fightersList.AddRange(fighters5Hashes);
            var fighterWords = WordsParsing.GetAllWords(fightersList.Distinct(), true, 2);
            ExportDictionary(folderSpecialized, "[SmashUltimate][ParamLabels][Specialized]Fighters", fighterWords);

            var stagesHashes = allHashes.Where(p => p.StartsWith("ui_stage_")).Select(p => p.Replace("ui_stage_", string.Empty));
            var stageWords = WordsParsing.GetAllWords(stagesHashes.Distinct(), true, 2);
            ExportDictionary(folderSpecialized, "[SmashUltimate][ParamLabels][Specialized]Stages", stageWords);

            var itemsHashes = allHashes.Where(p => p.StartsWith("item_kind_") && !p.StartsWith("ui_item_assist_")).Select(p => p.Replace("item_kind_", string.Empty));
            var items2Hashes = allHashes.Where(p => p.StartsWith("ui_item_")).Select(p => p.Replace("ui_item_", string.Empty));
            var assistHashes = allHashes.Where(p => p.StartsWith("ui_profile_as_")).Select(p => p.Replace("ui_profile_as_", string.Empty));
            var assist2Hashes = allHashes.Where(p => p.StartsWith("ui_item_assist_")).Select(p => p.Replace("ui_item_assist_", string.Empty));
            var spiritsHashes = allHashes.Where(p => p.StartsWith("ui_profile_se_")).Select(p => p.Replace("ui_profile_se_", string.Empty));
            var spirits2Hashes = allHashes.Where(p => p.StartsWith("ui_profile_sp_")).Select(p => p.Replace("ui_profile_sp_", string.Empty));
            var itemsList = itemsHashes.ToList();
            itemsList.AddRange(items2Hashes);
            itemsList.AddRange(assistHashes);
            itemsList.AddRange(assist2Hashes);
            itemsList.AddRange(spiritsHashes);
            itemsList.AddRange(spirits2Hashes);
            var itemsWords = WordsParsing.GetAllWords(itemsList.Distinct(), true, 2);
            ExportDictionary(folderSpecialized, "[SmashUltimate][ParamLabels][Specialized]Items_Assists_Spirits", itemsWords);

            var seriesHashes = allHashes.Where(p => p.StartsWith("ui_series_")).Select(p => p.Replace("ui_series_", string.Empty));
            var series2Hashes = allHashes.Where(p => p.StartsWith("ui_profile_em_")).Select(p => p.Replace("ui_profile_em_", string.Empty));
            var gameTitleHashes = allHashes.Where(p => p.StartsWith("ui_gametitle_")).Select(p => p.Replace("ui_gametitle_", string.Empty));
            var gamesList = seriesHashes.ToList();
            gamesList.AddRange(series2Hashes);
            gamesList.AddRange(gameTitleHashes);
            var gameWords = WordsParsing.GetAllWords(gamesList.Distinct(), true, 2);
            ExportDictionary(folderSpecialized, "[SmashUltimate][ParamLabels][Specialized]Games", gameWords);

            var bgmHashes = allHashes.Where(p => p.StartsWith("ui_bgm_")).Select(p => p.Replace("ui_bgm_", string.Empty));
            var bgmWordsAll = WordsParsing.GetAllWords(bgmHashes.Distinct(), false, 2);
            var bgmWordsNoDigits = WordsParsing.GetAllWords(bgmHashes.Distinct(), true, 2);
            ExportDictionary(folderSpecialized, "[SmashUltimate][ParamLabels][Specialized]Bgms_Full", bgmWordsAll);
            ExportDictionary(folderSpecialized, "[SmashUltimate][ParamLabels][Specialized]Bgms_Names", bgmWordsNoDigits);

            var actorsHashes = allHashes.Where(p => p.StartsWith("sound_actor_")).Select(p => p.Replace("sound_actor_", string.Empty));
            var actorsWords = WordsParsing.GetAllWords(actorsHashes.Distinct(), false, 2);
            ExportDictionary(folderSpecialized, "[SmashUltimate][ParamLabels][Specialized]Actors", actorsWords);

            //Files & Directories
            var filesHashes = allHashes.Where(p => p.Contains('.'));
            var directoryHashes = allHashes.Where(p => p.Contains('/'));
            var filesList = filesHashes.ToList();
            var filesWords = WordsParsing.GetAllWords(filesHashes);
            var directoriesWords = WordsParsing.GetAllWords(directoryHashes);
            filesList.AddRange(filesWords);
            filesList.AddRange(directoryHashes);
            filesList.AddRange(WordsParsing.GetAllWords(directoryHashes));
            ExportDictionary(folderSpecialized, "[SmashUltimate][ParamLabels][Specialized]File_Directories", filesList);

            var allWordsPlusDouble = WordsParsing.GetAllWords(allHashes, false, -1, -1, true);
            //Get all english words
            var outputEnglishWords = FilterWithDictionary(allWordsPlusDouble, allEnglishWords, o.MinimumCharactersDeepSearch);
            ExportDictionarySplitBySize(folderLanguage, "[SmashUltimate][ParamLabels][Language][English]", outputEnglishWords.Distinct());
            ExportDictionary(folderSpecialized, "[SmashUltimate][ParamLabels][Specialized]English_1-4_Letters", outputEnglishWords.Distinct().Where(p => p.Length < 5));
            ExportDictionary(folderSpecialized, "[SmashUltimate][ParamLabels][Specialized]English_5+_Letters", outputEnglishWords.Distinct().Where(p => p.Length >= 5));
            ExportDictionary(folderSpecialized, "[SmashUltimate][ParamLabels][Specialized]English_Common", outputEnglishWords.GroupBy(i => i).Where(p => p.Key.Length >= o.CommonWordsThresholdSizeMin).OrderByDescending(p => p.Count()).Take(o.CommonWordsThreshold).Select(p => p.Key));

            //Get all japanese words
            var outputJapaneseWords = FilterWithDictionary(allWordsPlusDouble, allJapaneseWords, o.MinimumCharactersDeepSearch);
            ExportDictionarySplitBySize(folderLanguage, "[SmashUltimate][ParamLabels][Language][Japanese]", outputJapaneseWords.Distinct());
            ExportDictionary(folderSpecialized, "[SmashUltimate][ParamLabels][Specialized]Japanese_1-4_Letters", outputJapaneseWords.Distinct().Where(p => p.Length < 5));
            ExportDictionary(folderSpecialized, "[SmashUltimate][ParamLabels][Specialized]Japanese_5+_Letters", outputJapaneseWords.Distinct().Where(p => p.Length >= 5));
            ExportDictionary(folderSpecialized, "[SmashUltimate][ParamLabels][Specialized]Japanese_Common", outputJapaneseWords.GroupBy(i => i).Where(p => p.Key.Length >= o.CommonWordsThresholdSizeMin).OrderByDescending(p => p.Count()).Take(o.CommonWordsThreshold).Select(p => p.Key));

            //- Technical word / dev language
            var techWords = allHashes.Where(p => p.Contains("_")).Select(p => p.Substring(p.LastIndexOf("_") + 1)).Where(p => p.All(char.IsLetter));
            ExportDictionary(folderSpecialized, "[SmashUltimate][ParamLabels][Specialized]LastWord_Common", techWords.GroupBy(i => i).Where(p => p.Key.Length >= o.CommonWordsThresholdSizeMin).OrderByDescending(p => p.Count()).Take(o.CommonWordsThreshold).Select(p => p.Key));

            //By Hits
            var groupedWords = WordsParsing.GetAllWords(allHashes, true, 2, -1, true).GroupBy(i => i).ToDictionary(p => p.Key, p => p.Count());
            foreach (var listByHitThreshold in _listByHits)
            {
                var validWords = groupedWords.Where(p => p.Value >= listByHitThreshold);
                ExportDictionary(folderByHits, $"[SmashUltimate][ParamLabels][ByHits]All_AtLeast_{listByHitThreshold:D2}hits", validWords.Select(p => p.Key));
            }

            groupedWords = outputEnglishWords.GroupBy(i => i).ToDictionary(p => p.Key, p => p.Count());
            foreach (var listByHitThreshold in _listByHits)
            {
                var validWords = groupedWords.Where(p => p.Value >= listByHitThreshold);
                ExportDictionary(folderByHits, $"[SmashUltimate][ParamLabels][ByHits]English_AtLeast_{listByHitThreshold:D2}hits", validWords.Select(p => p.Key));
            }

            //Other
            var otherList = new List<string>();
            otherList.AddRange(allWords);
            var exportOtherList = otherList
                .Except(numericHashes)
                .Except(fighterWords)
                .Except(stageWords)
                .Except(itemsWords)
                .Except(gameWords)
                .Except(actorsWords)
                .Except(bgmWordsAll)
                .Except(filesWords)
                .Except(directoriesWords)
                .Except(outputEnglishWords)
                .Except(outputJapaneseWords)
                .Except(techWords);
            ExportDictionary(folderSpecialized, "[SmashUltimate][ParamLabels][Specialized]Other", exportOtherList);
            ExportDictionary(folderSpecialized, "[SmashUltimate][ParamLabels][Specialized]Other_No_Digits", exportOtherList.Where(p => p.All(char.IsLetter)));
        }

        static void GenerateSmashWiiUDictionaries(Options o, string pathSmashWiiU, HashSet<string> allEnglishWords, HashSet<string> allJapaneseWords)
        {
            var folderSpecialized = Path.Combine(pathSmashWiiU, "Specialized");
            var folderLanguage = Path.Combine(pathSmashWiiU, "Language");
            var folderByHits = Path.Combine(pathSmashWiiU, "ByHits");

            var allHashesWiiU = File.ReadAllLines(o.InputFileSmashWiiU);

            IEnumerable<string> allHashes = allHashesWiiU.Distinct();
            var allWords = WordsParsing.GetAllWords(allHashes);

            //Export Full Dictionary
            ExportDictionary(folderSpecialized, "[SmashWiiU]Full", allWords);

            //Export Digits Only
            var numericHashes = allWords.Where(p => _regOnlyDigits.IsMatch(p));
            ExportDictionary(folderSpecialized, "[SmashWiiU][Specialized]Digits_Only", numericHashes);

            //Remove exclusively digits hashes
            allHashes = allHashes.Where(p => !_regOnlyDigits.IsMatch(p));

            //Nouns
            var fightersHashes = allHashes.Where(p => p.StartsWith("fighter/")).Select(p => p.Replace("fighter/", string.Empty));
            var fightersList = fightersHashes.ToList();
            var fighterWords = WordsParsing.GetAllWords(fightersList.Distinct(), true, 2);
            ExportDictionary(folderSpecialized, "[SmashWiiU][Specialized]Fighters", fighterWords);

            var stagesHashes = allHashes.Where(p => p.StartsWith("stage/")).Select(p => p.Replace("stage/", string.Empty));
            var stageWords = WordsParsing.GetAllWords(stagesHashes.Distinct(), true, 2);
            ExportDictionary(folderSpecialized, "[SmashWiiU][Specialized]Stages", stageWords);

            var itemsHashes = allHashes.Where(p => p.StartsWith("item/") && !p.StartsWith("item/assist/")).Select(p => p.Replace("item/", string.Empty));
            var items2Hashes = allHashes.Where(p => p.StartsWith("animcmd/item/")).Select(p => p.Replace("animcmd/item/", string.Empty));
            var assistHashes = allHashes.Where(p => p.StartsWith("item/assist/")).Select(p => p.Replace("item/assist/", string.Empty));
            var itemsList = itemsHashes.ToList();
            itemsList.AddRange(items2Hashes);
            itemsList.AddRange(assistHashes);
            var itemsWords = WordsParsing.GetAllWords(itemsList.Distinct(), true, 2);
            ExportDictionary(folderSpecialized, "[SmashWiiU][Specialized]Items_Assists", itemsWords);

            var allWordsPlusDouble = WordsParsing.GetAllWords(allHashes, false, -1, -1, true);
            //Get all english words
            var outputEnglishWords = FilterWithDictionary(allWordsPlusDouble, allEnglishWords, o.MinimumCharactersDeepSearch);
            ExportDictionarySplitBySize(folderLanguage, "[SmashWiiU][Language][English]", outputEnglishWords.Distinct());
            ExportDictionary(folderSpecialized, "[SmashWiiU][Specialized]English_1-4_Letters", outputEnglishWords.Distinct().Where(p => p.Length < 5));
            ExportDictionary(folderSpecialized, "[SmashWiiU][Specialized]English_5+_Letters", outputEnglishWords.Distinct().Where(p => p.Length >= 5));
            ExportDictionary(folderSpecialized, "[SmashWiiU][Specialized]English_Common", outputEnglishWords.GroupBy(i => i).Where(p => p.Key.Length >= o.CommonWordsThresholdSizeMin).OrderByDescending(p => p.Count()).Take(o.CommonWordsThreshold).Select(p => p.Key));

            //Get all japanese words
            var outputJapaneseWords = FilterWithDictionary(allWordsPlusDouble, allJapaneseWords, o.MinimumCharactersDeepSearch);
            ExportDictionarySplitBySize(folderLanguage, "[SmashWiiU][Language][Japanese]", outputJapaneseWords.Distinct());
            ExportDictionary(folderSpecialized, "[SmashWiiU][Specialized]Japanese_1-4_Letters", outputJapaneseWords.Distinct().Where(p => p.Length < 5));
            ExportDictionary(folderSpecialized, "[SmashWiiU][Specialized]Japanese_5+_Letters", outputJapaneseWords.Distinct().Where(p => p.Length >= 5));
            ExportDictionary(folderSpecialized, "[SmashWiiU][Specialized]Japanese_Common", outputJapaneseWords.GroupBy(i => i).Where(p => p.Key.Length >= o.CommonWordsThresholdSizeMin).OrderByDescending(p => p.Count()).Take(o.CommonWordsThreshold).Select(p => p.Key));

            //- Technical word / dev language
            var techWords = allHashes.Where(p => p.Contains("_")).Select(p => p.Substring(p.LastIndexOf("_") + 1)).Where(p => p.All(char.IsLetter));
            ExportDictionary(folderSpecialized, "[SmashWiiU][Specialized]LastWord_Common", techWords.GroupBy(i => i).Where(p => p.Key.Length >= o.CommonWordsThresholdSizeMin).OrderByDescending(p => p.Count()).Take(o.CommonWordsThreshold).Select(p => p.Key));

            //By Hits
            var groupedWords = WordsParsing.GetAllWords(allHashes, true, 2, -1, true).GroupBy(i => i, StringComparer.OrdinalIgnoreCase).ToDictionary(p => p.Key, p => p.Count());
            foreach (var listByHitThreshold in _listByHits)
            {
                var validWords = groupedWords.Where(p => p.Value >= listByHitThreshold);
                ExportDictionary(folderByHits, $"[SmashWiiU][ByHits]All_AtLeast_{listByHitThreshold:D2}hits", validWords.Select(p => p.Key.ToLower()));
            }

            groupedWords = outputEnglishWords.GroupBy(i => i, StringComparer.OrdinalIgnoreCase).ToDictionary(p => p.Key, p => p.Count());
            foreach (var listByHitThreshold in _listByHits)
            {
                var validWords = groupedWords.Where(p => p.Value >= listByHitThreshold);
                ExportDictionary(folderByHits, $"[SmashWiiU][ByHits]English_AtLeast_{listByHitThreshold:D2}hits", validWords.Select(p => p.Key.ToLower()));
            }

            //Other
            var otherList = new List<string>();
            otherList.AddRange(allWords);
            var exportOtherList = otherList
                .Except(numericHashes)
                .Except(fighterWords)
                .Except(stageWords)
                .Except(itemsWords)
                .Except(outputEnglishWords)
                .Except(outputJapaneseWords)
                .Except(techWords);
            ExportDictionary(folderSpecialized, "[SmashWiiU][Specialized]Other", exportOtherList);
            ExportDictionary(folderSpecialized, "[SmashWiiU][Specialized]Other_No_Digits", exportOtherList.Where(p => p.All(char.IsLetter)));
        }

        static void GenerateSmashPathDictionaries(Options o, string pathPath, HashSet<string> allEnglishWords, HashSet<string> allJapaneseWords)
        {
            var folderSpecialized = Path.Combine(pathPath, "Specialized");
            var folderLanguage = Path.Combine(pathPath, "Language");

            var allHashesPath = File.ReadAllLines(o.InputFilePathHashes);
            var allHashes = allHashesPath.Distinct();
            var allWords = WordsParsing.GetAllWords(allHashes);

            //Export Full Dictionary
            ExportDictionary(pathPath, "[SmashUltimate][Path]Full", allWords);

            //Export Digits Only
            var pathNumericHashes = allWords.Where(p => _regOnlyDigits.IsMatch(p));
            ExportDictionary(folderSpecialized, "[SmashUltimate][Path][Specialized]Digits_Only", pathNumericHashes);

            //Remove exclusively digits hashes
            allHashes = allHashes.Where(p => !_regOnlyDigits.IsMatch(p));

            //Nouns
            var pathFightersHashes = allHashes.Where(p => p.StartsWith("fighter/"));
            var pathFighterWords = WordsParsing.GetAllWords(pathFightersHashes.Distinct(), true, 2);
            ExportDictionary(folderSpecialized, "[SmashUltimate][Path][Specialized]Fighters", pathFighterWords);

            var pathStageHashes = allHashes.Where(p => p.StartsWith("stage/"));
            var pathStageWords = WordsParsing.GetAllWords(pathStageHashes.Distinct(), true, 2);
            ExportDictionary(folderSpecialized, "[SmashUltimate][Path][Specialized]Stage", pathStageWords);

            var pathAllWordsPlusDouble = WordsParsing.GetAllWords(allHashes, false, -1, -1, true);
            //Get all english words
            var pathOutputEnglishWords = FilterWithDictionary(pathAllWordsPlusDouble, allEnglishWords, o.MinimumCharactersDeepSearch);
            ExportDictionarySplitBySize(folderLanguage, "[SmashUltimate][Path][Language][English]", pathOutputEnglishWords.Distinct());
            ExportDictionary(folderSpecialized, "[SmashUltimate][Path][Specialized]English_1-4_Letters", pathOutputEnglishWords.Distinct().Where(p => p.Length < 5));
            ExportDictionary(folderSpecialized, "[SmashUltimate][Path][Specialized]English_5+_Letters", pathOutputEnglishWords.Distinct().Where(p => p.Length >= 5));
            ExportDictionary(folderSpecialized, "[SmashUltimate][Path][Specialized]English_Common", pathOutputEnglishWords.GroupBy(i => i).Where(p => p.Key.Length >= o.CommonWordsThresholdSizeMin).OrderByDescending(p => p.Count()).Take(o.CommonWordsThreshold).Select(p => p.Key));

            //Get all japanese words
            var pathOutputJapaneseWords = FilterWithDictionary(pathAllWordsPlusDouble, allJapaneseWords, o.MinimumCharactersDeepSearch);
            ExportDictionarySplitBySize(folderLanguage, "[SmashUltimate][Path][Language][Japanese]", pathOutputJapaneseWords.Distinct());
            ExportDictionary(folderSpecialized, "[SmashUltimate][Path][Specialized]Japanese_1-4_Letters", pathOutputJapaneseWords.Distinct().Where(p => p.Length < 5));
            ExportDictionary(folderSpecialized, "[SmashUltimate][Path][Specialized]Japanese_5+_Letters", pathOutputJapaneseWords.Distinct().Where(p => p.Length >= 5));
            ExportDictionary(folderSpecialized, "[SmashUltimate][Path][Specialized]Japanese_Common", pathOutputJapaneseWords.GroupBy(i => i).Where(p => p.Key.Length >= o.CommonWordsThresholdSizeMin).OrderByDescending(p => p.Count()).Take(o.CommonWordsThreshold).Select(p => p.Key));

            //Other
            var otherList = new List<string>();
            otherList.AddRange(allWords);
            var exportOtherList = otherList
                .Except(pathNumericHashes)
                .Except(pathFighterWords)
                .Except(pathStageWords)
                .Except(pathOutputEnglishWords)
                .Except(pathOutputJapaneseWords);
            ExportDictionary(folderSpecialized, "[SmashUltimate][Path][Specialized]Other", exportOtherList);
            ExportDictionary(folderSpecialized, "[SmashUltimate][Path][Specialized]Other_No_Digits", exportOtherList.Where(p => p.All(char.IsLetter)));
        }

        static void GenerateSmashKeyValueDictionary(Options o, string pathParamLabelsKeys)
        {
            var options = new HashKeys.Options
            {
                InputParamLabelsFile = o.InputParamLabelsFile,
                InputSmashRootPath = o.InputSmashRootPath,
                OutputPath = pathParamLabelsKeys,
                AddByHitsDic = true,
                AddLastWordDic = true
            };

            //All
            options.OutputPath = Path.Combine(pathParamLabelsKeys, "All");
            options.FormatString = "[SmashUltimate][ParamLabels]{0}[Key-Value]{1}[All]{2}.dic";
            options.IncludeFilterPath = "";
            HashKeys.Program.RunProgram(options);

            //Assist
            options.OutputPath = Path.Combine(pathParamLabelsKeys, "Assist");
            options.FormatString = "[SmashUltimate][ParamLabels]{0}[Key-Value]{1}[Assist]{2}.dic";
            options.IncludeFilterPath = "/assist";
            HashKeys.Program.RunProgram(options);

            //Boss
            options.OutputPath = Path.Combine(pathParamLabelsKeys, "Boss");
            options.FormatString = "[SmashUltimate][ParamLabels]{0}[Key-Value]{1}[Boss]{2}.dic";
            options.IncludeFilterPath = "/boss";
            HashKeys.Program.RunProgram(options);

            //Enemy
            options.OutputPath = Path.Combine(pathParamLabelsKeys, "Enemy");
            options.FormatString = "[SmashUltimate][ParamLabels]{0}[Key-Value]{1}[Enemy]{2}.dic";
            options.IncludeFilterPath = "/enemy";
            HashKeys.Program.RunProgram(options);

            //Fighter
            options.OutputPath = Path.Combine(pathParamLabelsKeys, "Fighter");
            options.FormatString = "[SmashUltimate][ParamLabels]{0}[Key-Value]{1}[Fighter]{2}.dic";
            options.IncludeFilterPath = "/fighter";
            HashKeys.Program.RunProgram(options);

            //Item
            options.OutputPath = Path.Combine(pathParamLabelsKeys, "Item");
            options.FormatString = "[SmashUltimate][ParamLabels]{0}[Key-Value]{1}[Item]{2}.dic";
            options.IncludeFilterPath = "/item";
            HashKeys.Program.RunProgram(options);

            //Param
            options.OutputPath = Path.Combine(pathParamLabelsKeys, "Param");
            options.FormatString = "[SmashUltimate][ParamLabels]{0}[Key-Value]{1}[Param]{2}.dic";
            options.IncludeFilterPath = "/param";
            HashKeys.Program.RunProgram(options);

            //Pokemon
            options.OutputPath = Path.Combine(pathParamLabelsKeys, "Pokemon");
            options.FormatString = "[SmashUltimate][ParamLabels]{0}[Key-Value]{1}[Pokemon]{2}.dic";
            options.IncludeFilterPath = "/pokemon";
            HashKeys.Program.RunProgram(options);

            //Stage
            options.OutputPath = Path.Combine(pathParamLabelsKeys, "Stage");
            options.FormatString = "[SmashUltimate][ParamLabels]{0}[Key-Value]{1}[Stage]{2}.dic";
            options.IncludeFilterPath = "/stage";
            HashKeys.Program.RunProgram(options);

            //UI
            options.OutputPath = Path.Combine(pathParamLabelsKeys, "UI");
            options.FormatString = "[SmashUltimate][ParamLabels]{0}[Key-Value]{1}[UI]{2}.dic";
            options.IncludeFilterPath = "/ui";
            HashKeys.Program.RunProgram(options);
        }

        static void GenerateMSBTValueDictionary(Options o, string pathMSBT)
        {
            var folderKeys = Path.Combine(pathMSBT, "Keys");
            var folderValues = Path.Combine(pathMSBT, "Values");
            var folderKeysByHits = Path.Combine(folderKeys, "ByHits");
            var folderValuesByHits = Path.Combine(folderValues, "ByHits");

            var msbtFiles = Directory.GetFiles(o.InputSmashRootPath, "*.msbt", SearchOption.AllDirectories);
            foreach (var msbtFile in msbtFiles)
            {
                if (msbtFile.Contains("+us_en"))
                {
                    var dictionary = MsbtHelper.GetMsbtValues(msbtFile);

                    var values = dictionary.Values.Select(p => Regex.Replace(p, "[^a-zA-Z0-9_]+", " ", RegexOptions.Compiled)).Select(p => p.ToLower()).ToList();
                    var allKeyWords = WordsParsing.GetAllWords(dictionary.Keys).Select(p => p.ToLower());
                    var allValueWords = WordsParsing.GetAllWords(values).SelectMany(p => p.Split(' ', StringSplitOptions.RemoveEmptyEntries)).Distinct();

                    var title = Path.GetFileName(msbtFile).Replace("+us_en.msbt", string.Empty);

                    ExportDictionary(folderKeys, $"[SmashUltimate][MSBT][Keys][{title}]Full", allKeyWords);
                    ExportDictionary(folderKeys, $"[SmashUltimate][MSBT][Keys][{title}]No_Digits", allKeyWords.Where(p => p.All(char.IsLetter)));
                    ExportDictionary(folderValues, $"[SmashUltimate][MSBT][Values][{title}]Full", allValueWords);
                    ExportDictionary(folderValues, $"[SmashUltimate][MSBT][Values][{title}]No_Digits", allValueWords.Where(p => p.All(char.IsLetter)));

                    //By Hits
                    var groupedKeyWords = WordsParsing.GetAllWords(dictionary.Keys, true, 2, -1, true).GroupBy(i => i).ToDictionary(p => p.Key, p => p.Count());
                    foreach (var listByHitThreshold in _listByHits)
                    {
                        var validWords = groupedKeyWords.Where(p => p.Value >= listByHitThreshold);
                        ExportDictionary(folderKeysByHits, $"[SmashUltimate][MSBT][Keys][ByHits][{title}]AtLeast_{listByHitThreshold:D2}hits", validWords.Select(p => p.Key));
                    }

                    var groupedValueWords = WordsParsing.GetAllWords(values, true, 2, -1, true).GroupBy(i => i).ToDictionary(p => p.Key, p => p.Count());
                    foreach (var listByHitThreshold in _listByHits)
                    {
                        var validWords = groupedValueWords.Where(p => p.Value >= listByHitThreshold);
                        ExportDictionary(folderValuesByHits, $"[SmashUltimate][MSBT][Values][ByHits][{title}]AtLeast_{listByHitThreshold:D2}hits", validWords.Select(p => p.Key));
                    }
                }
            }
        }

        static void ExportDictionary(string folder, string dictName, IEnumerable<string> lines)
        {
            if (lines.Any())
            {
                var path = Path.Combine(folder, dictName);
                var pathWithExtension = $"{path}.dic";
                Console.WriteLine($"Write '{dictName}' to '{pathWithExtension}'");
                Directory.CreateDirectory(folder);
                File.WriteAllLines(pathWithExtension, lines.OrderBy(p => p));
            }
        }

        static void ExportDictionarySplitBySize(string folder, string filename, IEnumerable<string> lines)
        {
            if (lines.Any())
            {
                var path = Path.Combine(folder, filename);
                Directory.CreateDirectory(folder);

                var dicts = new Dictionary<int, List<string>>();
                foreach (var word in lines)
                {
                    var count = Encoding.UTF8.GetByteCount(word);
                    if (!dicts.ContainsKey(count))
                        dicts.Add(count, new List<string>());
                    dicts[count].Add(word);
                }

                foreach (var linesDict in dicts)
                {
                    var dictNameSplit = $"{path}{linesDict.Key:D2}";
                    var pathWithExtension = $"{dictNameSplit}.dic";
                    Console.WriteLine($"Write '{dictNameSplit}' to '{pathWithExtension}'");
                    if (linesDict.Value.Count > 0)
                        File.WriteAllLines(pathWithExtension, linesDict.Value.OrderBy(p => p));
                }
            }
        }

        static IEnumerable<string> FilterWithDictionary(IEnumerable<string> lines, HashSet<string> dictionaryWords, int minimumWordsDeepSearch)
        {
            var outputWords = new List<string>();
            foreach (var word in lines)
            {
                if (word.Length < 2)
                    continue;

                //If 2-3 characters, we take the word as a whole
                if (word.Length < minimumWordsDeepSearch)
                {
                    if (dictionaryWords.Contains(word))
                        outputWords.Add(word);
                    else
                        continue;
                }

                //More than 4 character, full inspection
                var wordLength = word.Length;
                for (var i = 0; i <= wordLength - minimumWordsDeepSearch; i++)
                {
                    for (var j = minimumWordsDeepSearch; j < wordLength - i + 1; j++)
                    {
                        var candidate = word.Substring(i, j);
                        if (dictionaryWords.Contains(candidate))
                            outputWords.Add(candidate);
                    }
                }

            }
            return outputWords;
        }
    }
}
