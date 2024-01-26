using Force.Crc32;
using paracobNET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HashCommon
{
    public class HashHelper
    {
        private Dictionary<ulong, string> _paramLabels;

        public HashHelper(string inputFileParamLabels)
        {
            _paramLabels = GetParamLabels(inputFileParamLabels);
        }

        public ParamFile OpenParamFile(string inputFile)
        {
            var t = new ParamFile();
            t.Open(inputFile);
            return t;
        }

        public string GetHexaLabel(ulong hexValue)
        {
            if (hexValue == 0)
                return string.Empty;

            return _paramLabels.ContainsKey(hexValue) ? _paramLabels[hexValue] : ToHash40(hexValue);
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
            var hex = Crc32Algorithm.Compute(Encoding.UTF8.GetBytes(input));
            return $"0x{input.Length:x2}{hex:x8}";
        }

        public static string ToHash40(ulong input)
        {
            return $"0x{input:x10}";
        }
        #endregion
    }
}
