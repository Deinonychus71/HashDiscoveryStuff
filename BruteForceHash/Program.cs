using BruteForceHash.Helpers;
using BruteForceHash.Methods;
using CommandLine;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceHash
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Parser.Default.ParseArguments<Options>(args).WithParsedAsync(async (o) =>
            {
                //Cleaning
                o.ValidChars = string.Join(null, o.ValidChars.ToCharArray().Distinct());
                o.ValidStartingChars = string.Join(null, o.ValidStartingChars.ToCharArray().Distinct());

                //Get Hex
                if (string.IsNullOrEmpty(o.HexValue))
                {
                    Console.WriteLine("Enter hex to find: (for ex: 0x105274ba4f)");
                    o.HexValue = Console.ReadLine();
                }

                var hexValuesEntries = o.HexValue.Split(",", StringSplitOptions.RemoveEmptyEntries);

                //Run script
                Directory.CreateDirectory("HexData");
                foreach (var hexValueEntry in hexValuesEntries)
                {
                    Console.WriteLine($"-----------------------------------------");
                    using var logger = new Logger($"HexData/[{hexValueEntry}]/Results/{hexValueEntry}_{o.Method}_{DateTime.Now:yyyy_dd_MM_HH_mm_ss}.txt");
                    logger.Init();

                    var input = hexValueEntry.Trim();
                    logger.Log($"Hex Value: {input}");
                    logger.Log($"Use Hashcat: {(o.UseHashcat ? "Yes" : "No")}");
                    logger.Log($"Use UTF8: {(o.UseUTF8 ? "Yes" : "No")}");
                    logger.Log($"Description: {o.Description}");

                    var split = input.Split("x".ToCharArray());
                    var lengthStr = split[1].Substring(0, 2);
                    var valueStr = split[1][2..];
                    var length = Convert.ToInt32(lengthStr, 16);
                    logger.Log($"Length: {length}");
                    var hexToFind = Convert.ToUInt32(valueStr, 16);

                    if (!string.IsNullOrEmpty(o.Prefix))
                        logger.Log($"Prefix: {o.Prefix}");
                    if (!string.IsNullOrEmpty(o.Suffix))
                        logger.Log($"Suffix: {o.Suffix}");
                    logger.Log($"Number of Threads: {o.NbrThreads}");

                    if (Encoding.UTF8.GetByteCount(o.Prefix) + Encoding.UTF8.GetByteCount(o.Suffix) > length)
                    {
                        logger.Log($"Error: Prefix and/or Suffix is too long!");
                    }
                    else
                    {
                        //Run script
                        if (o.Method.Equals("dictionary", StringComparison.OrdinalIgnoreCase))
                        {
                            if (o.UseHashcat)
                                new DictionaryAttackHashcat(logger, o, length, hexToFind).Run();
                            else
                                new DictionaryAttack(logger, o, length, hexToFind).Run();
                        }
                        else if (o.Method.Equals("character", StringComparison.OrdinalIgnoreCase))
                        {
                            if (o.UseUTF8)
                                new CharacterAttackUtf8(logger, o, length, hexToFind).Run();
                            else if (o.UseHashcat)
                                new CharacterAttackHashCat(logger, o, length, hexToFind).Run();
                            else
                                new CharacterAttack(logger, o, length, hexToFind).Run();
                        }
                        else if (o.Method.Equals("hybrid", StringComparison.OrdinalIgnoreCase))
                        {
                            if (o.UseHashcat)
                                new HybridAttackHashCat(logger, o, length, hexToFind).Run();
                            else
                                new HybridAttack(logger, o, length, hexToFind).Run();
                        }
                        else
                            logger.Log("Method invalid");
                        await Task.Delay(2000);
                    }
                    logger.Log("-----------------------------------------");
                }

                Console.WriteLine($"{DateTime.Now.ToUniversalTime()} - Done!");
                if (o.ConfirmEnd)
                    Console.ReadLine();
                else
                    await Task.Delay(2000);
            });
        }
    }
}
