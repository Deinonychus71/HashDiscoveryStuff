using CommandLine;
using System;
using System.Threading.Tasks;

namespace BruteForceHash
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Parser.Default.ParseArguments<Options>(args).WithParsedAsync(async (o) =>
            {
                Console.WriteLine($"{DateTime.Now.ToUniversalTime()} - Hex Value: {o.HexValue}");

                string input = o.HexValue;
                var split = input.Split("x".ToCharArray());
                var lengthStr = split[1].Substring(0, 2);
                var valueStr = split[1][2..];
                var length = Convert.ToInt32(lengthStr, 16);
                Console.WriteLine($"{DateTime.Now.ToUniversalTime()} - Length: {length}");
                var hexToFind = Convert.ToUInt32(valueStr, 16);

                Console.WriteLine($"{DateTime.Now.ToUniversalTime()} - Delimiter: {o.Delimiter}");
                if (!string.IsNullOrEmpty(o.Prefix))
                    Console.WriteLine($"{DateTime.Now.ToUniversalTime()} - Prefix: {o.Prefix}");
                Console.WriteLine($"{DateTime.Now.ToUniversalTime()} - Number of Threads: {o.NbrThreads}");
                Console.WriteLine($"{DateTime.Now.ToUniversalTime()} - Words Limit: {o.WordsLimit}");
                Console.WriteLine($"{DateTime.Now.ToUniversalTime()} - Skip Digits: {o.SkipDigits}");

                //Run script
                await new BruteForceDictionary().Run(length, hexToFind, o.Delimiter, o.Prefix, o.SkipDigits, o.WordsLimit, o.NbrThreads);
                //new BruteForceLetter().Run(length, hexToFind, inputPrefix);

                Console.WriteLine($"{DateTime.Now.ToUniversalTime()} - Done!");
                Console.ReadKey();
            });
        }
    }
}
