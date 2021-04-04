using System;
using System.IO;
using System.Linq;

namespace HashSkipUnderscore
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                var words = File.ReadAllLines(args[0]);
                File.WriteAllLines($"{Path.GetFileNameWithoutExtension(args[0])}_skip.txt", words.Where(p => p.Contains('_') && !p.Contains("__")));
            }
        }
    }
}
