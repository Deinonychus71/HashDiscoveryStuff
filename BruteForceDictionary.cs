using BruteForceHash.Helpers;
using Force.Crc32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
					if (word.Any(char.IsDigit))
						continue;

					var lengthStr = word.Length.ToString();
					if (!output[lengthStr].Contains(word))
						output[lengthStr].Add(word);
				}
            }
			return output;
		}

		private void RunDictionaries(StringBuilder candidate, string combinationPattern, Dictionary<string, List<string>> dictWords, uint hexValue, string delimiter)
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
					candidate.Append(word);
					TestCandidate(candidate, hexValue);
					candidate.Remove(candidate.Length - word.Length, word.Length);
				}
				else
				{
					candidate.Append(word);
					candidate.Append(delimiter);
					RunDictionaries(candidate, combinationPattern, dictWords, hexValue, delimiter);
					int length = delimiter.Length + word.Length;
					candidate.Remove(candidate.Length - length, length);
				}
			}
		}

		private void TestCandidate(StringBuilder candidate, uint hexValue)
        {
			var testValue = Crc32Algorithm.Compute(Encoding.ASCII.GetBytes(candidate.ToString()));
			if (testValue == hexValue)
				Console.WriteLine($"{DateTime.Now.ToUniversalTime()} - Value found: {candidate}");
		}

		public void Run(int stringLength, uint hexValue, string delimiter = "_", string prefix = "", bool skipDigits = false, int nbrThreads = 16)
        {
			//Calculate stringLength after prefix;
			stringLength -= prefix.Length;

			//Generate combinations
			var combinationPatterns = GenerateCombinations(stringLength, delimiter);

			//Load dictionary
			var dictionaries = GetDictionaries(stringLength, delimiter);

			//Run
			var taskScheduler = new LimitedConcurrencyLevelTaskScheduler(nbrThreads);
			var tasks = new List<Task>();

			// Create a TaskFactory and pass it our custom scheduler.
			TaskFactory factory = new TaskFactory(taskScheduler);
			CancellationTokenSource cts = new CancellationTokenSource();

			foreach (var combinationPattern in combinationPatterns)
            {
				var task = factory.StartNew(() =>
				{
					var strBuilder = new StringBuilder();
					if (!string.IsNullOrEmpty(prefix))
					{
						strBuilder.Append(prefix);
					}
					Console.WriteLine($"Running Pattern: {combinationPattern}");
					RunDictionaries(strBuilder, combinationPattern, dictionaries, hexValue, delimiter);
				});
				tasks.Add(task);
			}

			// Wait for the tasks to complete before displaying a completion message.
			Task.WaitAll(tasks.ToArray());
			cts.Dispose();
		}
    }
}
