using Force.Crc32;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceHash
{
    public class BruteForceLetter
    {
        private static readonly string _validChars = "etainoshrdlucmfwygpbvkqjxz0123456789_./:-";
        private static readonly string _validStartChars = "etainoshrdlucmfwygpbvkqjxz";
        private static byte[] _validBytes = null;

        public void Run(int valueLength, uint hexToFind, string inputPrefix)
        {
            //Valid bytes
            Console.WriteLine($"Enter valid characters (Default: {_validChars}");
            string inputValidChars = Console.ReadLine();
            if (string.IsNullOrEmpty(inputValidChars))
                inputValidChars = _validChars;
            Console.WriteLine($"Will use {inputValidChars}");
            _validBytes = Encoding.ASCII.GetBytes(inputValidChars);

            //Valid bytes
            Console.WriteLine($"Enter valid first characters (Default: {_validStartChars}");
            string inputValidStartChars = Console.ReadLine();
            if (string.IsNullOrEmpty(inputValidStartChars))
                inputValidStartChars = _validStartChars;
            Console.WriteLine($"Will use {inputValidStartChars}");
            byte[] validStartBytes = Encoding.ASCII.GetBytes(inputValidStartChars);

            //Bruteforcing
            Console.WriteLine($"Starting at {DateTime.Now.ToLongTimeString()}...");
            Task[] tasks = new Task[validStartBytes.Length];
            for (var t = 0; t < validStartBytes.Length; t++)
            {
                var buffer = new byte[valueLength];
                for (var p = 0; p < inputPrefix.Length; p++)
                {
                    buffer[p] = (byte)inputPrefix[p];
                }
                buffer[inputPrefix.Length] = validStartBytes[t];
                tasks[t] = Task.Run(() =>
                {
                    Console.WriteLine($"Starting new thread for {Encoding.ASCII.GetString(new byte[1] { buffer[inputPrefix.Length] })}");
                    try
                    {
                        DiveByte(buffer, inputPrefix.Length + 1, valueLength, hexToFind);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"ERROR on thread {Encoding.ASCII.GetString(new byte[1] { buffer[inputPrefix.Length] })}: {e.Message}");
                    }
                });
            }

            Task.WaitAll(tasks);
        }

        private static void DiveByte(byte[] buffer, int level, int valueLength, uint hexToFind)
        {
            int levelp = level + 1;
            foreach (byte b in _validBytes)
            {
                if (levelp < valueLength)
                {
                    buffer[level] = b;
                    DiveByte(buffer, levelp, valueLength, hexToFind);
                    continue;
                }
                buffer[level] = b;
                var testValue = Crc32Algorithm.Compute(buffer);
                if (hexToFind == testValue)
                {
                    string value = Encoding.ASCII.GetString(buffer);
                    Console.WriteLine(value);
                    File.AppendAllLines($"0x{hexToFind:x}_{value[0]}.txt", new string[1] { $"0x{testValue:x}:{value}" });
                }
            }
        }

    }
}
