using paracobNET;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Hashing;
using System.Text;
using System.Text.RegularExpressions;

namespace HashCommon
{
    public class HashHelper
    {
        private readonly Dictionary<ulong, string> _paramLabels;

        public HashHelper(string inputFileParamLabels)
        {
            _paramLabels = GetParamLabels(inputFileParamLabels);
        }

        public static bool IsValidHash40Value(string hash40)
        {
            return !string.IsNullOrEmpty(hash40) && hash40.Length == 12 && Regex.Match(hash40, "0[xX[0-9a-fA-F]{10}").Success;
        }

        public static ParamFile OpenParamFile(string inputFile)
        {
            var t = new ParamFile();
            t.Open(inputFile);
            return t;
        }

        public string GetHexaLabel(ulong hexValue)
        {
            if (hexValue == 0)
                return string.Empty;

            return _paramLabels.TryGetValue(hexValue, out string value) ? value : ToHash40(hexValue);
        }

        #region Static
        public static Dictionary<ulong, string> GetParamLabels(string inputFileParamLabels)
        {
            var hashes = File.ReadAllLines(inputFileParamLabels);
            var output = new Dictionary<ulong, string>();

            foreach (var hash in hashes)
            {
                var hashSplit = hash.Split(",", StringSplitOptions.RemoveEmptyEntries);
                if (hashSplit.Length > 2)
                    throw new Exception("Bad ParamLabels");
                if (hashSplit.Length == 2)
                    output.Add(Convert.ToUInt64(hashSplit[0], 16), hashSplit[1]);
            }

            return output;
        }

        public static string ToHash40(string input)
        {
            var hex = Crc32.HashToUInt32(Encoding.UTF8.GetBytes(input));
            return $"0x{input.Length:x2}{hex:x8}";
        }

        public static string ToHash40(ulong input)
        {
            return $"0x{input:x10}";
        }
        #endregion
    }
}
