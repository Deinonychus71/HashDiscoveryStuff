using paracobNET;
using System;
using System.Collections.Generic;
using System.IO;

namespace HashParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = @"C:\Users\deihn\Desktop\bruteforcepublish\params11";

            var filesPrc = Directory.GetFiles(input, "*.prc", SearchOption.AllDirectories);
            var filesStPrm = Directory.GetFiles(input, "*.stprm", SearchOption.AllDirectories);
            var filesStDat = Directory.GetFiles(input, "*.stdat", SearchOption.AllDirectories);
            var dictHashes = GetParamLabels("ParamLabels.csv");
            var output = new List<ExcelEntry>();

            foreach (var file in filesPrc)
            {
                var t = new ParamFile();
                t.Open(file);

                foreach(var prm in t.Root.Nodes)
                {
                    if (prm.Value.TypeKey == ParamType.list)
                    {
                        //TODO
                    }
                    else if (prm.Value.TypeKey == ParamType.hash40)
                    {
                        var valueHex = (ulong)(prm.Value as ParamValue).Value;
                        output.Add(new ExcelEntry()
                        {
                            File = file,
                            KeyHexa = $"0x{prm.Key:x}",
                            KeyLabel = GetHexaTitle(dictHashes, prm.Key),
                            Type = prm.Value.TypeKey.ToString(),
                            ValueHexa = $"0x{valueHex:x}",
                            ValueLabel = GetHexaTitle(dictHashes, valueHex)
                        });
                    }
                    else if(prm.Value.TypeKey == ParamType.@struct)
                    {
                        var prmStruct = prm.Value as ParamStruct;
                        //foreach(prmStruct.Nodes
                    }
                    else
                    {
                        output.Add(new ExcelEntry()
                        {
                            File = file,
                            KeyHexa = $"0x{prm.Key:x}",
                            KeyLabel = GetHexaTitle(dictHashes, prm.Key),
                            Type = prm.Value.TypeKey.ToString(),
                            ValueLabel = ((ParamValue)prm.Value).Value.ToString()
                        });
                    }
                }
            }
        }

        private static string GetHexaTitle(Dictionary<ulong, string> dict, ulong hexValue)
        {
            return dict.ContainsKey(hexValue) ? dict[hexValue] : string.Empty;
        }

        private static Dictionary<ulong, string> GetParamLabels(string inputFileParamLabels)
        {
            var hashes = File.ReadAllLines(inputFileParamLabels);
            var output = new Dictionary<ulong, string>();

            foreach (var hash in hashes)
            {
                var hashSplit = hash.Split(",", StringSplitOptions.RemoveEmptyEntries);
                if (hashSplit.Length > 2)
                    Console.WriteLine("wtf");
                if(hashSplit.Length == 2)
                    output.Add(Convert.ToUInt64(hashSplit[0], 16), hashSplit[1]);
            }

            return output;
        }
    }
}
