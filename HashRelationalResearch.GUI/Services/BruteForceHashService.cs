using CsvHelper.Delegates;
using HashRelationalResearch.GUI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashRelationalResearch.GUI.Services
{
    public class BruteForceHashService : IBruteForceHashService
    {
        public void StartProcess(bool useHashCat = false)
        {
            /*var hex = GetHex();
            var hexFolder = GetHexFolder();

            var dictionaries = string.Empty;
            var dictionariesCustom = string.Empty;
            var dictionariesExclude = string.Empty;
            var dictionariesFirstWordCustom = string.Empty;
            var dictionariesFirstWordExclude = string.Empty;
            var dictionariesLastWordCustom = string.Empty;
            var dictionariesLastWordExclude = string.Empty;
            var dictionariesFirstWord = string.Empty;
            var dictionariesLastWord = string.Empty;
            var dictionaryHybrid = string.Empty;
            var dictionaryHybridFirstWord = string.Empty;
            var dictionaryHybridLastWord = string.Empty;

            SaveCustomDictionaries();
            if (chkDictionariesUse.Checked)
                dictionaries = GetDictionary(tvDictMain);
            if (chkDictionariesCustomWordsUse.Checked && File.Exists($"{hexFolder}\\[{hex}].dic"))
                dictionariesCustom = $"{hexFolder}\\[{hex}].dic";
            if (chkDictionariesExcludeWordsUse.Checked && File.Exists($"{hexFolder}\\[{hex}][Exclude].dic"))
                dictionariesExclude = $"{hexFolder}\\[{hex}][Exclude].dic";

            if (chkUseDictFirst.Checked)
                dictionariesFirstWord = GetDictionary(tvDictFirstWord);
            if (chkDictionariesFirstWordCustomWordsUse.Checked && File.Exists($"{hexFolder}\\[{hex}][1st].dic"))
                dictionariesFirstWordCustom = $"{hexFolder}\\[{hex}][1st].dic";
            if (chkDictionariesFirstWordExcludeWordsUse.Checked && File.Exists($"{hexFolder}\\[{hex}][1st][Exclude].dic"))
                dictionariesFirstWordExclude = $"{hexFolder}\\[{hex}][1st][Exclude].dic";

            if (chkUseDictLast.Checked)
                dictionariesLastWord = GetDictionary(tvDictLastWord);
            if (chkDictionariesLastWordCustomWordsUse.Checked && File.Exists($"{hexFolder}\\[{hex}][Last].dic"))
                dictionariesLastWordCustom = $"{hexFolder}\\[{hex}][Last].dic";
            if (chkDictionariesLastWordExcludeWordsUse.Checked && File.Exists($"{hexFolder}\\[{hex}][Last][Exclude].dic"))
                dictionariesLastWordExclude = $"{hexFolder}\\[{hex}][Last][Exclude].dic";

            if (chkHybridDictUse.Checked && File.Exists($"{hexFolder}\\[{hex}][Hybrid].dic"))
                dictionaryHybrid = $"{hexFolder}\\[{hex}][Hybrid].dic";
            if (chkHybridDictFirstWordUse.Checked && File.Exists($"{hexFolder}\\[{hex}][Hybrid][1st].dic"))
                dictionaryHybridFirstWord = $"{hexFolder}\\[{hex}][Hybrid][1st].dic";
            if (chkHybridDictLastWordUse.Checked && File.Exists($"{hexFolder}\\[{hex}][Hybrid][Last].dic"))
                dictionaryHybridLastWord = $"{hexFolder}\\[{hex}][Hybrid][Last].dic";

            var useUtf8 = !useHashCat && chkUtf8Toggle.Checked;
            var useMethodDictionary = cbMethod.SelectedItem.ToString() == "Dictionary";
            var useMethodCharacter = cbMethod.SelectedItem.ToString() == "Character";
            var useMethodHybrid = cbMethod.SelectedItem.ToString() == "Hybrid";
            var useDictAdvanced = chkDictionaryAdvanced.Checked;

            //Common All
            string arguments = $"--nbr_threads {cbNbThreads.SelectedItem} " +
                                $"--method {(useMethodDictionary ? "dictionary" : useMethodCharacter ? "character" : useMethodHybrid ? "hybrid" : string.Empty)} " +
                                $"{(chkVerbose.Checked ? "--verbose" : "")} " +
                                $"--confirm_end " +
                                $"--prefix \"{txtPrefix.Text.Trim()}\" " +
                                $"--suffix \"{txtSuffix.Text.Trim()}\" " +
                                $"--path_hashcat \"{txtHashCatPath.Text.Trim()}\" " +
                                $"--hex_value \"{txtHexValues.Text.Trim()}\" ";

            //Common Dictionary & Hybrid
            if (useMethodDictionary || useMethodHybrid)
            {
                arguments += $"--words_limit {cbWordsLimit.SelectedItem} " +
                                $"--max_delimiters {cbMaxDelim.SelectedItem} " +
                                $"--min_delimiters {cbMinDelim.SelectedItem} " +
                                $"--max_word_length {cbMaxWordLength.SelectedItem} " +
                                $"--min_word_length {cbMinWordLength.SelectedItem} " +
                                $"--max_ones {cbMaxOnes.SelectedItem} " +
                                $"--min_ones {cbMinOnes.SelectedItem} " +
                                $"--max_twos {cbMaxTwos.SelectedItem} " +
                                $"--min_twos {cbMinTwos.SelectedItem} " +
                                $"--max_threes {cbMaxThrees.SelectedItem} " +
                                $"--min_threes {cbMinThrees.SelectedItem} " +
                                $"--max_fours {cbMaxFours.SelectedItem} " +
                                $"--min_fours {cbMinFours.SelectedItem} " +
                                (cbAtLeastAboveNbrChars.SelectedIndex > 0 ? $"--at_least_gte_chars {cbAtLeastAboveNbrChars.SelectedIndex} " +
                                $"--at_least_gte_words {cbAtLeastAboveNbrWords.SelectedIndex} " : string.Empty) +
                                (cbAtLeastUnderNbrChars.SelectedIndex > 0 ? $"--at_least_lte_chars {cbAtLeastUnderNbrChars.SelectedIndex} " +
                                $"--at_least_lte_words {cbAtLeastUnderNbrWords.SelectedItem} " : string.Empty) +
                                (cbAtMostAboveNbrChars.SelectedIndex > 0 ? $"--at_most_gte_chars {cbAtMostAboveNbrChars.SelectedIndex} " +
                                $"--at_most_gte_words {cbAtMostAboveNbrWords.SelectedIndex} " : string.Empty) +
                                (cbAtMostUnderNbrChars.SelectedIndex > 0 ? $"--at_most_lte_chars {cbAtMostUnderNbrChars.SelectedIndex} " +
                                $"--at_most_lte_words {cbAtMostUnderNbrWords.SelectedItem} " : string.Empty) +
                                $"--order_algorithm {GetCombinationOrderName()} " +
                                $"{(GetCombinationOrderLongerFirst() ? "--order_longer_words_first" : "")} " +
                                $"--include_word \"{txtIncludeWord.Text.Trim()}\" " +
                                $"{(chkIncludeWordNotFirst.Checked ? "--include_word_not_first" : "")} " +
                                $"{(chkIncludeWordNotLast.Checked ? "--include_word_not_last" : "")} " +
                                $"--include_patterns \"{txtIncludePatterns.Text.Trim()}\" " +
                                $"--exclude_patterns \"{txtExcludePatterns.Text.Trim()}\" " +
                                $"--delimiter \"{txtDelimiter.Text.Trim()}\" ";
            }

            //Common Dictionary & Hybrid Avanced
            if (useDictAdvanced && (useMethodDictionary || (useMethodHybrid && !chkHybridIgnoreSizeFilters.Checked)))
            {
                arguments += $"--min_words_limit {cbMinWordsLimit.SelectedItem} " +
                    $"--max_concatenated_words {cbMaxConcatWords.SelectedItem} " +
                    $"--min_concatenated_words {cbMinConcatWords.SelectedItem} " +
                    $"{(chkOnlyLastTwoWordsConcat.Checked ? "--only_last_two_concatenated" : "")} " +
                    $"{(chkOnlyFirstTwoWordsConcat.Checked ? "--only_first_two_concatenated" : "")} " +
                    $"--max_consecutive_concatenation_limit {cbMaxConsecutiveConcat.SelectedItem} " +
                    $"--min_consecutive_concatenation_limit {cbMinConsecutiveConcat.SelectedItem} " +
                    $"--max_consecutive_ones {cbMaxConsecutiveOnes.SelectedItem} ";
            }

            //Dictionary Only
            if (useMethodDictionary)
            {
                arguments += $"{(chkDictCachePrefix.Checked ? "--enable_dynamic_prefix_cache" : "")} " +
                                $"{(chkDictCacheSuffix.Checked ? "--enable_dynamic_suffix_cache" : "")} " +
                                $"{(chkDictionariesUse.Checked && chkDictSkipDigits.Checked ? "--dictionaries_skip_digits" : "")} " +
                                $"{(chkDictionariesUse.Checked && chkDictSkipSpecials.Checked ? "--dictionaries_skip_specials" : "")} " +
                                $"{(chkDictionariesUse.Checked && chkDictForceLowercase.Checked ? "--dictionaries_force_lowercase" : "")} " +
                                $"{(chkDictionariesUse.Checked && chkDictAddTypos.Checked ? "--dictionaries_add_typos" : "")} " +
                                $"{(chkDictionariesUse.Checked && chkDictReverseOrder.Checked ? "--dictionaries_reverse_order" : "")} " +
                                $"{(chkDictionariesCustomWordsUse.Checked && chkDictCustomWordsSkipDigits.Checked ? "--dictionaries_custom_skip_digits" : "")} " +
                                $"{(chkDictionariesCustomWordsUse.Checked && chkDictCustomWordsSkipSpecials.Checked ? "--dictionaries_custom_skip_specials" : "")} " +
                                $"{(chkDictionariesCustomWordsUse.Checked && chkDictCustomWordsForceLowercase.Checked ? "--dictionaries_custom_force_lowercase" : "")} " +
                                $"{(chkDictionariesCustomWordsUse.Checked && chkDictCustomWordsAddTypos.Checked ? "--dictionaries_custom_add_typos" : "")} " +
                                (chkDictionariesCustomWordsUse.Checked ? $"--dictionaries_custom_min_words_hash {cbDictionariesCustomWordsMinimumInHash.SelectedItem} " : string.Empty) +
                                (chkDictionariesCustomWordsUse.Checked && chkDictionariesCustomWordsMinimumInHashUseTypos.Checked ? "--dictionaries_custom_min_words_hash_use_typos" : string.Empty) +
                                $"{(chkUseDictFirst.Checked && chkDictFirstSkipDigits.Checked ? "--dictionaries_first_skip_digits" : "")} " +
                                $"{(chkUseDictFirst.Checked && chkDictFirstSkipSpecials.Checked ? "--dictionaries_first_skip_specials" : "")} " +
                                $"{(chkUseDictFirst.Checked && chkDictFirstForceLowercase.Checked ? "--dictionaries_first_force_lowercase" : "")} " +
                                $"{(chkUseDictFirst.Checked && chkDictFirstAddTypos.Checked ? "--dictionaries_first_add_typos" : "")} " +
                                $"{(chkUseDictFirst.Checked && chkDictFirstReverseOrder.Checked ? "--dictionaries_first_reverse_order" : "")} " +
                                $"{(chkDictionariesFirstWordCustomWordsUse.Checked && chkDictFirstWordCustomWordsSkipDigits.Checked ? "--dictionaries_first_custom_skip_digits" : "")} " +
                                $"{(chkDictionariesFirstWordCustomWordsUse.Checked && chkDictFirstWordCustomWordsSkipSpecials.Checked ? "--dictionaries_first_custom_skip_specials" : "")} " +
                                $"{(chkDictionariesFirstWordCustomWordsUse.Checked && chkDictFirstWordCustomWordsForceLowercase.Checked ? "--dictionaries_first_custom_force_lowercase" : "")} " +
                                $"{(chkDictionariesFirstWordCustomWordsUse.Checked && chkDictFirstWordCustomWordsAddTypos.Checked ? "--dictionaries_first_custom_add_typos" : "")} " +
                                $"{(chkUseDictLast.Checked && chkDictLastSkipDigits.Checked ? "--dictionaries_last_skip_digits" : "")} " +
                                $"{(chkUseDictLast.Checked && chkDictLastSkipSpecials.Checked ? "--dictionaries_last_skip_specials" : "")} " +
                                $"{(chkUseDictLast.Checked && chkDictLastForceLowercase.Checked ? "--dictionaries_last_force_lowercase" : "")} " +
                                $"{(chkUseDictLast.Checked && chkDictLastAddTypos.Checked ? "--dictionaries_last_add_typos" : "")} " +
                                $"{(chkUseDictLast.Checked && chkDictLastReverseOrder.Checked ? "--dictionaries_last_reverse_order" : "")} " +
                                $"{(chkDictionariesLastWordCustomWordsUse.Checked && chkDictLastWordCustomWordsSkipDigits.Checked ? "--dictionaries_last_custom_skip_digits" : "")} " +
                                $"{(chkDictionariesLastWordCustomWordsUse.Checked && chkDictLastWordCustomWordsSkipSpecials.Checked ? "--dictionaries_last_custom_skip_specials" : "")} " +
                                $"{(chkDictionariesLastWordCustomWordsUse.Checked && chkDictLastWordCustomWordsForceLowercase.Checked ? "--dictionaries_last_custom_force_lowercase" : "")} " +
                                $"{(chkDictionariesLastWordCustomWordsUse.Checked && chkDictLastWordCustomWordsAddTypos.Checked ? "--dictionaries_last_custom_add_typos" : "")} " +
                                $"{(chkTyposSkipDoubleLetter.Checked ? "--typos_enable_skip_double_letter" : "")} " +
                                $"{(chkTyposSkipLetter.Checked ? "--typos_enable_skip_letter" : "")} " +
                                $"{(chkTyposDoubleLetter.Checked ? "--typos_enable_double_letter" : "")} " +
                                $"{(chkTyposExtraLetter.Checked ? "--typos_enable_extra_letter" : "")} " +
                                $"{(chkTyposWrongLetter.Checked ? "--typos_enable_wrong_letter" : "")} " +
                                $"{(chkTyposReverseLetter.Checked ? "--typos_enable_reverse_letter" : "")} " +
                                (!string.IsNullOrEmpty(txtTyposSwapLetters.Text.Trim()) ? $"--typos_enable_letter_swap \"{txtTyposSwapLetters.Text.Trim()}\" " : string.Empty) +
                                (!string.IsNullOrEmpty(txtTyposAppendLetters.Text.Trim()) ? $"--typos_enable_append_letters \"{txtTyposAppendLetters.Text.Trim()}\" " : string.Empty) +
                                (chkDictionariesUse.Checked ? $"--dictionaries \"{dictionaries}\" " : string.Empty) +
                                (chkUseDictFirst.Checked ? $"--dictionaries_first_word \"{dictionariesFirstWord}\" " : string.Empty) +
                                (chkUseDictLast.Checked ? $"--dictionaries_last_word \"{dictionariesLastWord}\" " : string.Empty) +
                                (chkDictionariesCustomWordsUse.Checked ? $"--dictionaries_custom \"{dictionariesCustom}\" " : string.Empty) +
                                (chkDictionariesFirstWordCustomWordsUse.Checked ? $"--dictionaries_first_word_custom \"{dictionariesFirstWordCustom}\" " : string.Empty) +
                                (chkDictionariesLastWordCustomWordsUse.Checked ? $"--dictionaries_last_word_custom \"{dictionariesLastWordCustom}\" " : string.Empty) +
                                (chkDictionariesExcludeWordsUse.Checked ? $"--dictionaries_exclude \"{dictionariesExclude}\" " : string.Empty) +
                                $"{(chkDictionariesExcludeWordsUse.Checked && chkDictExcludePartialWords.Checked ? "--dictionaries_exclude_partial" : "")} " +
                                (chkDictionariesFirstWordExcludeWordsUse.Checked ? $"--dictionaries_first_word_exclude \"{dictionariesFirstWordExclude}\" " : string.Empty) +
                                $"{(chkDictionariesFirstWordExcludeWordsUse.Checked && chkDictFirstWordExcludePartialWords.Checked ? "--dictionaries_first_word_exclude_partial" : "")} " +
                                (chkDictionariesLastWordExcludeWordsUse.Checked ? $"--dictionaries_last_word_exclude \"{dictionariesLastWordExclude}\" " : string.Empty) +
                                $"{(chkDictionariesLastWordExcludeWordsUse.Checked && chkDictLastWordExcludePartialWords.Checked ? "--dictionaries_last_word_exclude_partial" : "")} " +
                                (!string.IsNullOrEmpty(txtDictionaryFilterFirstFrom.Text.Trim()) ? $"--dictionary_filter_first_from \"{txtDictionaryFilterFirstFrom.Text.Trim()}\" " : string.Empty) +
                                (!string.IsNullOrEmpty(txtDictionaryFilterFirstTo.Text.Trim()) ? $"--dictionary_filter_first_to \"{txtDictionaryFilterFirstTo.Text.Trim()}\" " : string.Empty);
            }

            //Common Character & Hybrid
            if (useMethodCharacter || useMethodHybrid)
            {
                arguments += $"--valid_chars \"{txtValidCharsPreview.Text.Trim().Replace("\\", "\\\\").Replace("\"", "\\\"")}\" " +
                                $"--valid_starting_chars \"{txtStartingValidCharsPreview.Text.Trim().Replace("\\", "\\\\").Replace("\"", "\\\"")}\" " +
                                $"{(useHashCat ? "--use_hashcat" : "")} ";
            }

            //Character only
            if (useMethodCharacter)
            {
                arguments += $"{(useUtf8 ? "--use_utf8" : "")} ";
            }

            //Hybrid only
            if (useMethodHybrid)
            {
                arguments += $" --hybrid_words_hash {cbHybridWordsInHash.SelectedItem} " +
                                $"--hybrid_min_characters {cbHybridBruteForceMinCharacters.SelectedItem} " +
                                $"--hybrid_max_characters {cbHybridBruteForceMaxCharacters.SelectedItem} " +
                                (useHashCat ? $"--hybrid_min_char_hashcat_threshold {cbHybridHashcatThreshold.SelectedItem} " : string.Empty) +
                                (chkHybridIgnoreSizeFilters.Checked ? $"--hybrid_ignore_size_filters " : string.Empty) +
                                (chkHybridDictUse.Checked ? $"--hybrid_dictionary \"{dictionaryHybrid}\" " : string.Empty) +
                                (chkHybridDictFirstWordUse.Checked ? $"--hybrid_dictionary_first_word \"{dictionaryHybridFirstWord}\" " : string.Empty) +
                                (chkHybridDictLastWordUse.Checked ? $"--hybrid_dictionary_last_word \"{dictionaryHybridLastWord}\" " : string.Empty);
            }


            using (var process = new Process())
            {
                process.StartInfo.FileName = "BruteForceHash.exe";
                process.StartInfo.Arguments = arguments;
                _lastCommand = process.StartInfo.Arguments;

                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.WaitForExit();
                process.Close();
            }*/
        }
    }
}
