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
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed((o) =>
            {
                RunProgram(o);
            });
        }

        public static void RunProgram(Options o)
        {
            var dictHashes = File.ReadAllLines(o.InputParamLabelsFile).Select(p => p.Split(',', StringSplitOptions.RemoveEmptyEntries)).Where(p => p.Length == 2).ToDictionary(p => p[0].Replace("0x0", "0x"), p => p[1]);
            var fileMain = File.ReadAllLines(o.InputFileMain);

            for (int i = 0; i < fileMain.Length; i++)
            {
                if (!fileMain[i].Contains("0x"))
                    continue;

                foreach (var dictHash in dictHashes)
                {
                    if (fileMain[i].Contains(dictHash.Key))
                        fileMain[i] = fileMain[i].Replace(dictHash.Key, $"\"{dictHash.Value}\"");
                }
            }

            File.WriteAllLines(o.OutputFileMain, fileMain);
        }
    }
}