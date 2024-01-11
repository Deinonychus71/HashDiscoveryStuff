using MsbtEditor;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashCommon
{
    public static class MsbtHelper
    {
        public static Dictionary<string, string> GetMsbtValues(string inputFile)
        {
            var msbtFile = new MSBT(inputFile);
            var dict = new Dictionary<string, string>();

            foreach (var msbtEntry in msbtFile.LBL1.Labels)
            {
                var value = msbtFile.TXT2.OriginalStrings.FirstOrDefault(p => p.Index == msbtEntry.Index);
                dict.Add(((Label)msbtEntry).Name, Encoding.Unicode.GetString(value.Value).TrimEnd('\0'));
            }

            return dict;
        }
    }
}
