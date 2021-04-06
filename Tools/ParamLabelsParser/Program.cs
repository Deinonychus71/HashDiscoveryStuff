using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ParamLabelsParser
{
    class Program
    {
        private static readonly char[] _splitChars = new char[] {',','.','\\','/','_' };
        private readonly static Regex _regOnlyDigits = new Regex(@"^[0-9]+$", RegexOptions.Compiled);

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed((o) =>
            {
                var paramLabelFile = o.ParamLabelsFile;
                var dictFileEnglish = o.EnglishDictionary;
                var dictFileJapanese = o.JapaneseDictionary;

                var allEnglishWords = File.Exists(dictFileEnglish) ? File.ReadAllLines(dictFileEnglish).Select(p => p.ToLower()).Distinct().ToHashSet() : new HashSet<string>();
                var allJapaneseWords = File.Exists(dictFileJapanese) ? File.ReadAllLines(dictFileJapanese).Select(p => p.ToLower()).Distinct().ToHashSet() : new HashSet<string>();
                var allHashes = File.ReadAllLines(paramLabelFile).Where(p => p.Contains(',')).Select(p => p.Split(',')[1]).Where(p => !string.IsNullOrEmpty(p));
                var allWords = GetAllWords(allHashes);

                //Export Full Dictionary
                ExportDictionary("[Smash]_PL_Full.dic", allWords);

                //Export Digits Only
                var numericHashes = allWords.Where(p => _regOnlyDigits.IsMatch(p));
                ExportDictionary("[Smash]_PL_Digits.dic", numericHashes);

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
                var fighterWords = GetAllWords(fightersList.Distinct(), true, 2);
                ExportDictionary("[Smash]_PL_Fighters.dic", fighterWords);

                var stagesHashes = allHashes.Where(p => p.StartsWith("ui_stage_")).Select(p => p.Replace("ui_stage_", string.Empty));
                var stageWords = GetAllWords(stagesHashes.Distinct(), true, 2);
                ExportDictionary("[Smash]_PL_Stages.dic", stageWords);

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
                var itemsWords = GetAllWords(itemsList.Distinct(), true, 2);
                ExportDictionary("[Smash]_PL_Items+Assists+Spirits.dic", itemsWords);

                var seriesHashes = allHashes.Where(p => p.StartsWith("ui_series_")).Select(p => p.Replace("ui_series_", string.Empty));
                var series2Hashes = allHashes.Where(p => p.StartsWith("ui_profile_em_")).Select(p => p.Replace("ui_profile_em_", string.Empty));
                var gameTitleHashes = allHashes.Where(p => p.StartsWith("ui_gametitle_")).Select(p => p.Replace("ui_gametitle_", string.Empty));
                var gamesList = seriesHashes.ToList();
                gamesList.AddRange(series2Hashes);
                gamesList.AddRange(gameTitleHashes);
                var gameWords = GetAllWords(gamesList.Distinct(), true, 2);
                ExportDictionary("[Smash]_PL_Games.dic", gameWords);

                var bgmHashes = allHashes.Where(p => p.StartsWith("ui_bgm_")).Select(p => p.Replace("ui_bgm_", string.Empty));
                var bgmWordsAll = GetAllWords(bgmHashes.Distinct(), false, 2);
                var bgmWordsNoDigits = GetAllWords(bgmHashes.Distinct(), true, 2);
                ExportDictionary("[Smash]_PL_Bgms_Full.dic", bgmWordsAll);
                ExportDictionary("[Smash]_PL_Bgms_Names.dic", bgmWordsNoDigits);

                var actorsHashes = allHashes.Where(p => p.StartsWith("sound_actor_")).Select(p => p.Replace("sound_actor_", string.Empty));
                var actorsWords = GetAllWords(actorsHashes.Distinct(), false, 2);
                ExportDictionary("[Smash]_PL_Actors.dic", actorsWords);

                //Files & Directories
                var filesHashes = allHashes.Where(p => p.Contains('.'));
                var directoryHashes = allHashes.Where(p => p.Contains('/'));
                var filesList = filesHashes.ToList();
                var filesWords = GetAllWords(filesHashes);
                var directoriesWords = GetAllWords(directoryHashes);
                filesList.AddRange(filesWords);
                filesList.AddRange(directoryHashes);
                filesList.AddRange(GetAllWords(directoryHashes));
                ExportDictionary("[Smash]_PL_File+Directories.dic", filesList);

                var allWordsPlusDouble = GetAllWords(allHashes, false, -1, -1, true);
                //Get all english words
                var outputEnglishWords = FilterWithDictionary(allWordsPlusDouble, allEnglishWords, o.MinimumCharactersDeepSearch);
                ExportDictionary("[Smash]_PL_ENG_1-4_Letters.dic", outputEnglishWords.Distinct().Where(p => p.Length < 5));
                ExportDictionary("[Smash]_PL_ENG_5+_Letters.dic", outputEnglishWords.Distinct().Where(p => p.Length >= 5));
                ExportDictionary("[Smash]_PL_ENG_Common.dic", outputEnglishWords.GroupBy(i => i).Where(p => p.Key.Length >= o.CommonWordsThresholdSizeMin).OrderByDescending(p => p.Count()).Take(o.CommonWordsThreshold).Select(p => p.Key));

                //Get all japanese words
                var outputJapaneseWords = FilterWithDictionary(allWordsPlusDouble, allJapaneseWords, o.MinimumCharactersDeepSearch);
                ExportDictionary("[Smash]_PL_JPN_1-4_Letters.dic", outputJapaneseWords.Distinct().Where(p => p.Length < 5));
                ExportDictionary("[Smash]_PL_JPN_5+_Letters.dic", outputJapaneseWords.Distinct().Where(p => p.Length >= 5));
                ExportDictionary("[Smash]_PL_JPN_Common.dic", outputJapaneseWords.GroupBy(i => i).Where(p => p.Key.Length >= o.CommonWordsThresholdSizeMin).OrderByDescending(p => p.Count()).Take(o.CommonWordsThreshold).Select(p => p.Key));

                //- Technical word / dev language
                var techWords = allHashes.Where(p => p.Contains("_")).Select(p => p.Substring(p.LastIndexOf("_") + 1)).Where(p => p.All(char.IsLetter));
                ExportDictionary("[Smash]_PL_LastWord_Common.dic", techWords.GroupBy(i => i).Where(p => p.Key.Length >= o.CommonWordsThresholdSizeMin).OrderByDescending(p => p.Count()).Take(o.CommonWordsThreshold).Select(p => p.Key));

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
                ExportDictionary("[Smash]_PL_Other.dic", exportOtherList);
                ExportDictionary("[Smash]_PL_Other_No_Digits.dic", exportOtherList.Where(p => p.All(char.IsLetter)));
            });
        }

        static void ExportDictionary(string filename, IEnumerable<string> lines)
        {
            File.WriteAllLines(filename, lines.OrderBy(p => p));
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

        static IEnumerable<string> GetAllWords(IEnumerable<string> lines, bool skipDigits = false, int minLength = -1, int maxLength = -1, bool keepDouble = false)
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

                    if (keepDouble || (!keepDouble &&!output.Contains(splitWord)))
                        output.Add(splitWord);
                }
            }
            return output;
        }

        #region Utils
        static IEnumerable<string> SplitWords(IEnumerable<string> input, int currentIndex)
        {
            if (currentIndex < _splitChars.Length)
            {
                input = input.SelectMany(p => p.Split(_splitChars[currentIndex], System.StringSplitOptions.RemoveEmptyEntries));
                return SplitWords(input, currentIndex + 1);
            }
            return input;
        }
        #endregion
    }
}
