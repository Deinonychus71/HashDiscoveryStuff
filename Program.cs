using System;

namespace BruteForceHash
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get Hex
            Console.WriteLine("Enter hex to find: (for ex: 0x105274ba4f or 0x0ff71e57ec)");
            string input = Console.ReadLine();
            var split = input.Split("x".ToCharArray());
            var lengthStr = split[1].Substring(0, 2);
            var valueStr = split[1][2..];
            var length = Convert.ToInt32(lengthStr, 16);
            Console.WriteLine($"Length: {length}");
            var hexToFind = Convert.ToUInt32(valueStr, 16);
            Console.WriteLine($"Value to find: 0x{hexToFind:x}");

            //Run script
            new BruteForceDictionary().Run(length, hexToFind);
            new BruteForceLetter().Run(length, hexToFind);

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
