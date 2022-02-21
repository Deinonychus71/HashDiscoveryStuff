using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HashCleanup
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Append prefix?");
            var prefix = Console.ReadLine();
            Console.WriteLine("Append suffix?");
            var suffix = Console.ReadLine();
            Console.WriteLine("Skip if no underscore? (1 for yes, 0 for no, default no)");
            var skipUnderscoreRead = Console.ReadLine();
            var skipUndescore = false;
            if (int.TryParse(skipUnderscoreRead, out int resultUnderscore) && resultUnderscore == 1)
                skipUndescore = true;
            Console.WriteLine("Skip digits in middle? (1 for yes, 0 for no, default no)");
            var skipDigitsRead = Console.ReadLine();
            var skipDigits = false;
            if (int.TryParse(skipDigitsRead, out int resultDigits) && resultDigits == 1)
                skipDigits = true;
            Console.WriteLine("Check for at least 1 word in the dictionary? (1 for yes, 0 for no, default no)");
            var skipCheckWord = Console.ReadLine();
            var checkDictionary = false;
            var charactersNumber = 5;
            if (int.TryParse(skipCheckWord, out int resultCheckWord) && resultCheckWord == 1)
            {
                checkDictionary = true;
                Console.WriteLine("How many characters? (5 is default)");
                var characterNumberRead = Console.ReadLine();
                if (int.TryParse(characterNumberRead, out int resultCharacterNumber))
                {
                    charactersNumber = resultCharacterNumber;
                }
            }

            HashSet<string> dict = new HashSet<string>();
            if(checkDictionary == true)
            {
                var lines = File.ReadAllLines("dict_cleanup.dic").Distinct().Select(p => p.ToLower());
                foreach (var line in lines)
                    dict.Add(line);
            }

            if (args.Length == 1)
            {
                var words = File.ReadAllLines(args[0]);

                var newWords = words.Select(p => FormatForHashcat(p))
                    .Where(p => !p.Contains("__")) //This one should run no matter what
                    .Where(p => !skipUndescore || p.Contains('_'))
                    .Where(p => !skipDigits || CheckForDigits(p))
                    .Where(p => !checkDictionary || CheckForDictionary(p, charactersNumber, dict))
                    .Select(p => $"{prefix}{p}{suffix}")
                    .Where(p => !p.StartsWith('_') && !p.EndsWith('_'))
                    .Distinct()
                    .OrderBy(p => p)
                    .ToList();

                File.WriteAllLines($"{Path.GetFileNameWithoutExtension(args[0])}_cleanup.txt", newWords);
            }
        }

        private static string FormatForHashcat(string input)
        {
            if (input.Contains(':'))
                return input[(input.LastIndexOf(':') + 1)..];
            else
                return input;

        }

        private static bool CheckForDigits(string input)
        {
            if (input.Length <= 2)
                return true;

            var splitInput = input.Split('_');
            foreach (var word in splitInput)
            {
                bool letterFound = false;
                bool digitFoundAfterLetter = false;
                for(int i = 0; i< word.Length; i++)
                {
                    if (digitFoundAfterLetter && !char.IsDigit(word[i]))
                        return false;
                    else if (!char.IsDigit(word[i]))
                        letterFound = true;
                    else if (letterFound && char.IsDigit(word[i]) )
                        digitFoundAfterLetter = true;
                }
            }
            return true;
        }

        private static bool CheckForDictionary(string input, int charactersNumber, HashSet<string> dictionary)
        {
            if (input.Length < charactersNumber)
                return true;

            var length = input.Length - charactersNumber;
            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < length - i + 1; j++)
                {
                    var word = input[i..^j];
                    if (dictionary.Contains(word))
                        return true;
                }
            }
            return false;
        }
    }
}
