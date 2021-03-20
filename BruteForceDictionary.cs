using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BruteForceHash
{
    public class BruteForceDictionary
    {
		private IEnumerable<string> GenerateCombinations(int stringLength, string delimiter)
        {
			var alreadyFoundMap = new Dictionary<int, List<string>>();
			for (var i = 1; i <= stringLength; i++)
			{
				alreadyFoundMap[i] = GenerateValidCombinations(i, alreadyFoundMap, delimiter);
			}
			return alreadyFoundMap[stringLength].OrderBy(p => p.Length);
		}

		private List<string> GenerateValidCombinations(int stringLength, Dictionary<int, List<string>> alreadyFoundMap, string delimiter)
        {
			var returnCombinations = new List<string>();
			if (stringLength == 1)
			{
				returnCombinations.Add("1");
			}
			else if (stringLength == 0)
			{
				returnCombinations.Add("invalid");
			}
			else if (stringLength == -1)
			{
				returnCombinations.Add("ended");
			}
			else
			{
				for (int i = 1; i <= stringLength; i++)
				{
					var remainingLength = stringLength - i - 1;
					var pattern = i.ToString();
					List<string> subCombinations;
					if (alreadyFoundMap.ContainsKey(remainingLength))
					{
						subCombinations = alreadyFoundMap[remainingLength];
					}
					else
					{
						subCombinations = GenerateValidCombinations(remainingLength, alreadyFoundMap, delimiter);
					}

					foreach (var remainingStringPattern in subCombinations)
					{
						if (remainingStringPattern == "ended")
						{
							returnCombinations.Add(pattern);
						}
						else if (remainingStringPattern != "invalid")
						{
							returnCombinations.Add($"{pattern}{delimiter}{remainingStringPattern}");
						}
					}

				}

			}
			return returnCombinations;
		}

		private Dictionary<string, List<string>> GetDictionaries(int stringLength, string delimiter)
        {
			var output = new Dictionary<string, List<string>>();
			var lengthSkip = delimiter.Length > 0 ? stringLength - delimiter.Length : stringLength + 1;

			for (int i = 1; i <= stringLength; i++)
				output.Add(i.ToString(), new List<string>());

			var allDictionaries = Directory.GetFiles("Dictionaries", "*.txt");
			foreach(var dictionaryPath in allDictionaries)
            {
				var allWords = File.ReadAllLines(dictionaryPath);
				foreach(var word in allWords)
                {
					if (word.Length > stringLength || word.Length == lengthSkip || word.Length == 0)
						continue;

					var lengthStr = word.Length.ToString();
					if (!output[lengthStr].Contains(word))
						output[lengthStr].Add(word);
				}
            }

			return output;
		}

		private void RunDictionaries(string candidate, string combinationPattern, Dictionary<string, List<string>> dictWords, string delimiter)
        {
			string wordSize;
			bool lastWord = false;

			if (!combinationPattern.Contains(delimiter))
			{
				wordSize = combinationPattern;
				lastWord = true;
			}
			else
			{
				wordSize = combinationPattern.Substring(0, combinationPattern.IndexOf(delimiter));
				combinationPattern = combinationPattern.Substring(combinationPattern.IndexOf(delimiter) + delimiter.Length);
				
			}

			var words = dictWords[wordSize];
			foreach (var word in words)
			{
				if (lastWord)
				{
					TestCandidate($"{candidate}{word}");
				}
				else
				{
					RunDictionaries($"{candidate}{word}{delimiter}", combinationPattern, dictWords, delimiter);
				}
			}
		}

		private void TestCandidate(string candidate)
        {
			if (candidate == "air_sp_all")
				Console.WriteLine("FOUND");
			//Console.WriteLine(candidate);
		}

		public void Run(int stringLength, uint hexValue, string delimiter = "_")
        {
			//Generate combinations
			var combinationPatterns = GenerateCombinations(stringLength, delimiter);

			//Load dictionary
			var dictionaries = GetDictionaries(stringLength, delimiter);

			//Run
			string candidate = string.Empty;
			
			foreach(var combinationPattern in combinationPatterns)
            {
				Console.WriteLine(combinationPattern);
				RunDictionaries(candidate, combinationPattern, dictionaries, delimiter);
			}
		}
    }
}
