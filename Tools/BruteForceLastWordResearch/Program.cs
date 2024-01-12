using CommandLine;
using HashCommon;
using paracobNET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BruteForceLastWordResearch
{
    /// <summary>
    /// Split the paramlabel words using different value types to make dictionary. Require prc/stprm/stdat files.
    /// </summary>
    public class Program
    {
        private const string DICT_LIST = "List";
        private const string DICT_STRUCT = "Struct";
        private const string DICT_BOOLEAN = "Boolean";
        private const string DICT_HASH40KEY = "Hash40";
        private const string DICT_STRINGKEY = "String";
        private const string DICT_HASH40VALUE = "[Values]Hash40";
        private const string DICT_STRINGVALUE = "[Values]String";
        private const string DICT_FLOAT = "[Numeric]Float";
        private const string DICT_BYTE = "[Numeric]Byte";
        private const string DICT_INT = "[Numeric]Int";
        private const string DICT_SBYTE = "[Numeric]SByte";
        private const string DICT_SHORT = "[Numeric]Short";
        private const string DICT_UINT = "[Numeric]UInt";
        private const string DICT_USHORT = "[Numeric]UShort";
        private static int[] _listByHits = new int[] { 2, 3, 4, 5, 10, 15, 20 };

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed((o) =>
            {
                RunProgram(o);
            });
        }

        public static void RunProgram(Options o)
        {
            if (!Directory.Exists(o.InputSmashRootPath))
            {
                Console.WriteLine($"Directory '{o.InputSmashRootPath}' does not exist");
                return;
            }

            if (!File.Exists(o.InputUncrackedHashesGrouped))
            {
                Console.WriteLine($"File '{o.InputUncrackedHashesGrouped}' does not exist");
                return;
            }

            Directory.CreateDirectory(o.OutputPath);

            
        }
    }
}
