using System;
using System.IO;
using System.Linq;

namespace HashReOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length ==1)
            {
                var words = File.ReadAllLines(args[0]);
                File.WriteAllLines($"{Path.GetFileNameWithoutExtension(args[0])}_sorted.txt", words.OrderBy(p => p));
            }
        }
    }
}
