﻿using BruteForceHash.Helpers;
using CommandLine;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BruteForceHash
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Parser.Default.ParseArguments<Options>(args).WithParsedAsync(async (o) =>
            {
                //Get Hex
                if (string.IsNullOrEmpty(o.HexValue))
                {
                    Console.WriteLine("Enter hex to find: (for ex: 0x105274ba4f)");
                    o.HexValue = Console.ReadLine();
                }

                var hexValuesEntries = o.HexValue.Split(",", StringSplitOptions.RemoveEmptyEntries);

                //Run script
                Directory.CreateDirectory("Results");
                foreach (var hexValueEntry in hexValuesEntries)
                {
                    Console.WriteLine($"-----------------------------------------");
                    using var logger = new Logger($"Results/{hexValueEntry}_{o.Method}_{DateTime.Now:yyyy_dd_MM_HH_mm_ss}.txt");
                    logger.Init();

                    var input = hexValueEntry.Trim();
                    logger.Log($"Hex Value: {input}");

                    var split = input.Split("x".ToCharArray());
                    var lengthStr = split[1].Substring(0, 2);
                    var valueStr = split[1][2..];
                    var length = Convert.ToInt32(lengthStr, 16);
                    logger.Log($"Length: {length}");
                    var hexToFind = Convert.ToUInt32(valueStr, 16);

                    if (!string.IsNullOrEmpty(o.Prefix))
                        logger.Log($"Prefix: {o.Prefix}");
                    logger.Log($"Number of Threads: {o.NbrThreads}");
                    logger.Log($"Skip Digits: {o.SkipDigits}");

                    //Run script
                    if (o.Method.Equals("dictionary", StringComparison.OrdinalIgnoreCase))
                        new BruteForceDictionary(logger, o, length, hexToFind).Run();
                    else if (o.Method.Equals("letter", StringComparison.OrdinalIgnoreCase))
                        new BruteForceLetter(logger, o, length, hexToFind).Run();
                    else
                        logger.Log("Method invalid");

                    logger.Log("-----------------------------------------");

                    await Task.Delay(2000);
                }

                Console.WriteLine($"{DateTime.Now.ToUniversalTime()} - Done!");
                if (o.ConfirmEnd)
                    Console.ReadKey();
            });
        }
    }
}
