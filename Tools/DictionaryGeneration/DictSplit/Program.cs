using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DictSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                foreach (var arg in args)
                {
                    string input = arg;
                    if (File.Exists(arg))
                    {
                        var allWords = File.ReadAllLines(input).Distinct().OrderBy(p => p);
                        var fileName = string.Empty;
                        var prePath = string.Empty;
                        var path = Path.GetDirectoryName(input);

                        if (input.Contains("]"))
                        {
                            prePath = input.Substring(0, input.LastIndexOf(']') + 1);
                            fileName = input.Substring(input.LastIndexOf(']') + 1);
                        }
                        else
                        {
                            fileName = Path.GetFileName(input);
                            prePath = Path.GetFullPath(input);
                        }

                        var dicts = new Dictionary<int, List<string>>();
                        foreach (var word in allWords)
                        {
                            var count = Encoding.UTF8.GetByteCount(word);
                            if (!dicts.ContainsKey(count))
                                dicts.Add(count, new List<string>());
                            dicts[count].Add(word);
                        }

                        foreach (var dict in dicts)
                        {
                            File.WriteAllLines(Path.Combine(path, $"{prePath}[{Path.GetFileNameWithoutExtension(fileName)}]{dict.Key.ToString("D2")}{Path.GetExtension(fileName)}"), dict.Value.ToArray());
                        }
                    }
                }
            }

        }
    }
}
