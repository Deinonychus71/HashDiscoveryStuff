using CommandLine;
using CsvHelper;
using CsvHelper.Configuration;
using HashCommon;
using paracobNET;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace HashTable
{
    class Program
    {
        private static HashHelper _hashHelper;

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed((o) =>
            {
                if (!File.Exists(o.InputFile))
                {
                    Console.WriteLine($"File '{o.InputFile}' does not exist.");
                    return;
                }

                if (string.IsNullOrEmpty(o.InputFileList))
                {
                    Console.WriteLine($"Please enter the name of a list inside the PRC file.");
                    return;
                }

                if (!File.Exists(o.InputParamLabelsFile))
                {
                    Console.WriteLine($"File '{o.InputParamLabelsFile}' does not exist.");
                    return;
                }

                try
                {
                    _hashHelper = new HashHelper(o.InputParamLabelsFile);
                    var paramFile = _hashHelper.OpenParamFile(o.InputFile);

                    foreach (var prm in paramFile.Root.Nodes)
                    {
                        SearchParamStruct(prm, o.InputFileList, o.OutputCSV);
                    }
                    Console.WriteLine("Done!");
                }
                catch(Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            });

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void SearchParamStruct(HashValuePair<IParam> node, string listName, string outputCSV)
        {
            if (node.Value.TypeKey == ParamType.list)
            {
                var list = (ParamList)node.Value;
                string keyLabel = _hashHelper.GetHexaLabel(node.Key);

                if (keyLabel == listName)
                {
                    ParseList(list, outputCSV);
                }
            }
            else if (node.Value.TypeKey == ParamType.@struct)
            {
                foreach (var prm in ((ParamStruct)node.Value).Nodes)
                {
                    SearchParamStruct(prm, listName, outputCSV);
                }
            }
        }

        private static void ParseList(ParamList paramList, string outputCSV)
        {
            var csvDict = new List<OrderedDictionary<string, object>>();

            int i = 0;
            foreach (var prm in paramList.Nodes)
            {
                if (prm.TypeKey == ParamType.@struct)
                {
                    csvDict.Add(ParseStruct((ParamStruct)prm, i));
                }

                else if (prm.TypeKey == ParamType.list)
                {
                    Console.WriteLine("Check ParamList");
                }
                else if (prm.TypeKey == ParamType.hash40)
                {
                    Console.WriteLine("Check ParamHash40");
                }
                i++;
            }

            ExportCSV(csvDict, outputCSV);
        }

        private static OrderedDictionary<string, object> ParseStruct(ParamStruct paramStruct, int index)
        {
            var csvDictEntry = new OrderedDictionary<string, object>();
            csvDictEntry.Add("ID", index);
            
            foreach (var prm in paramStruct.Nodes)
            {
                var key = _hashHelper.GetHexaLabel(prm.Key);
                switch (prm.Value.TypeKey)
                {
                    case ParamType.@struct:
                        csvDictEntry.Add(key, "<Struct>");
                        break;
                    case ParamType.list:
                        csvDictEntry.Add(key, "<List>");
                        break;
                    case ParamType.hash40:
                        var valueHex = (ulong)(prm.Value as ParamValue).Value;
                        csvDictEntry.Add(key, _hashHelper.GetHexaLabel(valueHex));
                        break;
                    default:
                        csvDictEntry.Add(key, ((ParamValue)prm.Value).Value.ToString());
                        break;
                }
            }
            return csvDictEntry;
        }

        private static void ExportCSV(List<OrderedDictionary<string, object>> csvDict, string outputCSV)
        {
            using (var writer = new StringWriter())
            {
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = "," }))
                {
                    var hasHeaderBeenWritten = false;
                    foreach (var row in csvDict)
                    {
                        if (!hasHeaderBeenWritten)
                        {
                            foreach (var pair in row)
                            {
                                csv.WriteField(pair.Key);
                            }

                            hasHeaderBeenWritten = true;

                            csv.NextRecord();
                        }

                        foreach (var pair in row)
                        {
                            csv.WriteField(pair.Value);
                        }

                        csv.NextRecord();
                    }

                    var result = writer.ToString();
                    File.WriteAllText(outputCSV, result);
                }
            }
        }
    }
}
