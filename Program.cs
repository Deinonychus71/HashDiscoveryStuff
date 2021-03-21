using System;

namespace BruteForceHash
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get Hex
            Console.WriteLine("Enter hex to find: (for ex: 0x105274ba4f, 0x0ff71e57ec, 0x1d7feb1956 or 0x21bee0c6ef)");
            string input = Console.ReadLine();
            var split = input.Split("x".ToCharArray());
            var lengthStr = split[1].Substring(0, 2);
            var valueStr = split[1][2..];
            var length = Convert.ToInt32(lengthStr, 16);
            Console.WriteLine($"{DateTime.Now.ToUniversalTime()} - Length: {length}");
            var hexToFind = Convert.ToUInt32(valueStr, 16);
            Console.WriteLine($"{DateTime.Now.ToUniversalTime()} - Value to find: 0x{hexToFind:x}");

            //Prefix?
            Console.WriteLine($"Try prefix? (Default: None)");
            string inputPrefix = Console.ReadLine();
            Console.WriteLine($"Prefix: {inputPrefix}");

            //Run script
            new BruteForceDictionary().Run(length, hexToFind, "_", inputPrefix, true, 32);
            //new BruteForceLetter().Run(length, hexToFind, inputPrefix);

            Console.WriteLine("{DateTime.Now.ToUniversalTime()} - Done!");
            Console.ReadKey();
        }
    }
}
