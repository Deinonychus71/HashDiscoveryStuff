using CommandLine;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WikiScrapper
{
    class Program
    {
        private static readonly char[] _splitChars = new char[] { '-', '_' };
        private static string _virtualFolder = "/"; // /wiki/
        private readonly static Regex _specialCharactersRegex = new Regex("^[a-zA-Z0-9_]*$", RegexOptions.Compiled);

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed((o) =>
            {
                var allEnglishWords = File.Exists(o.EnglishDictionary) ? File.ReadAllLines(o.EnglishDictionary).Select(p => p.ToLower()).Distinct().ToHashSet() : new HashSet<string>();
                var currentDictionary = File.Exists(o.OutputDictionary) ? File.ReadAllLines(o.OutputDictionary).Select(p => p.ToLower()).Distinct().ToHashSet() : new HashSet<string>();
                var scrapUrls = new List<string>() { o.InputUrl };
                var baseUrl = new Uri(o.InputUrl).GetLeftPart(UriPartial.Authority);
                var alreadyScrappedUrls = new HashSet<string>();

                var web = new HtmlWeb();

                while (scrapUrls.Count != 0)
                {
                    var scrapUrl = scrapUrls[0];
                    if (scrapUrl.StartsWith('/'))
                        scrapUrl = $"{baseUrl}{scrapUrl}";
                    if (scrapUrl.Contains('#'))
                        scrapUrl = scrapUrl.Substring(0, scrapUrl.IndexOf("#"));
                    var doc = web.Load(scrapUrl);
                    var content = doc.GetElementbyId("mw-content-text");

                    var contentElements = content.SelectNodes(
                        "//*/div[@class='mw-parser-output']/p | " +
                        "//*/div[@class='mw-parser-output']/h1 | " +
                        "//*/div[@class='mw-parser-output']/h2 | " +
                        "//*/div[@class='mw-parser-output']/h3 | " +
                        "//*/div[@class='mw-parser-output']/h4 | " +
                        "//*/div[@class='mw-parser-output']/table/*/td | " +
                        "//*/div[@class='mw-parser-output']/div[@class='gallerytext'] | " +
                        "//*/div[@class='mw-parser-output']/a | " +
                        "//*/div[@class='mw-parser-output']/*/p | " +
                        "//*/div[@class='mw-parser-output']/*/h1 | " +
                        "//*/div[@class='mw-parser-output']/*/h2 | " +
                        "//*/div[@class='mw-parser-output']/*/h3 | " +
                        "//*/div[@class='mw-parser-output']/*/h4 | " +
                        "//*/div[@class='mw-parser-output']/*/table/*/td | " +
                        "//*/div[@class='mw-parser-output']/*/div[@class='gallerytext'] | " +
                        "//*/div[@class='mw-parser-output']/*/a | " +
                        "//*/div[@class='mw-parser-output']/a");

                    if (contentElements != null)
                    {
                        foreach (var contentElement in contentElements)
                        {
                            switch (contentElement.Name)
                            {
                                case "a":
                                    AddUrlToScrap(contentElement, scrapUrls, alreadyScrappedUrls);
                                    break;
                                default:
                                    AddWordsToDictionary(contentElement.InnerText, currentDictionary, allEnglishWords, o.RemoveDigits, o.RemoveSpecials, o.RemoveAccents);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Skipping {scrapUrl}.");
                    }

                    alreadyScrappedUrls.Add(scrapUrls[0]);
                    scrapUrls.RemoveAt(0);

                    File.WriteAllLines(o.OutputDictionary, currentDictionary.OrderBy(p => p));
                }
            });
        }

        static void AddUrlToScrap(HtmlNode aNode, List<string> scrapUrls, HashSet<string> alreadyScrappedUrls)
        {
            var link = aNode.GetAttributeValue("href", "");
            if (link.Contains('#'))
                link = link.Substring(0, link.IndexOf("#"));
            if (!string.IsNullOrEmpty(link) && !scrapUrls.Contains(link) && !alreadyScrappedUrls.Contains(link) && link.StartsWith(_virtualFolder) && !link.StartsWith($"{_virtualFolder}Special:") && !link.StartsWith($"{_virtualFolder}File:"))
                scrapUrls.Add(link);
        }

        static void AddWordsToDictionary(string text, HashSet<string> currentDictionary, HashSet<string> dictEnglish, bool skipDigits, bool skipSpecials, bool skipAccents)
        {
            var words = SplitWords(text.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries), 0);

            foreach (var word in words)
            {
                string checkWord = Regex.Replace(word, @"\W+$", "", RegexOptions.Compiled);

                if (currentDictionary.Contains(checkWord) || dictEnglish.Contains(checkWord))
                    continue;

                if (skipDigits && !checkWord.All(char.IsLetter))
                    continue;

                if (string.IsNullOrEmpty(checkWord))
                {
                    continue;
                }

                if (skipSpecials && !_specialCharactersRegex.IsMatch(checkWord))
                {
                    //Special detected, try cleaning accents
                    string jpnCleanedWord = checkWord.Replace('ō', 'o').Replace("ā", "a").Replace("é", "e").Replace("ī", "i").Replace("ï", "i").Replace("ū", "u").Replace("ð", "o").Replace("ä", "a").Replace("è", "e").Replace("ē", "e");

                    bool copyJpn = true;
                    if (!_specialCharactersRegex.IsMatch(jpnCleanedWord))
                    {
                        //Still not good
                        jpnCleanedWord = Regex.Replace(jpnCleanedWord, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                        if (string.IsNullOrEmpty(jpnCleanedWord))
                            continue;
                        copyJpn = false;
                    }
                    if (!_specialCharactersRegex.IsMatch(jpnCleanedWord))
                    {
                        //Still not good, bye bye
                        continue;
                    }
                    else
                    {
                        //Good! - We add the original word if requested
                        if (copyJpn && !skipAccents && !currentDictionary.Contains(checkWord) && !dictEnglish.Contains(checkWord))
                        {
                            currentDictionary.Add(checkWord);
                        }
                        //The word was changed. Check it against dictionary
                        if (currentDictionary.Contains(jpnCleanedWord) || dictEnglish.Contains(checkWord))
                            continue;

                        //The cleaned word passed all the tests
                        checkWord = jpnCleanedWord;
                    }
                }

                currentDictionary.Add(checkWord);
            }
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
