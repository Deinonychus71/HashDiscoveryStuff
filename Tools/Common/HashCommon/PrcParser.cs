using paracobNET;
using System.Collections.Generic;
using System.Linq;

namespace HashCommon
{
    public static class PrcParser
    {
        public static PrcStruct ParsePrcFile(string file)
        {
            return ParsePrcFile(file, new Dictionary<ulong, string>(), false);
        }

        public static PrcStruct ParsePrcFile(string file, string paramLabelsFile, bool solveLabels = true)
        {
            var paramLabels = HashHelper.GetParamLabels(paramLabelsFile);
            return ParsePrcFile(file, paramLabels, solveLabels);
        }

        public static PrcStruct ParsePrcFile(string file, Dictionary<ulong, string> paramLabels, bool solveLabels = true)
        {
            var t = new ParamFile();
            t.Open(file);

            return ParseStruct(paramLabels, null, t.Root.Nodes, solveLabels);
        }

        private static PrcStruct ParseStruct(Dictionary<ulong, string> dictHashes, PrcNode parentNode, Hash40Pairs<IParam> nodes, bool solveLabels)
        {
            var o = new PrcStruct() { Nodes = new List<PrcNode>() };

            foreach (var prm in nodes)
            {
                o.Nodes.Add(ParseIParam(dictHashes, parentNode, 0, prm.Key, prm.Value, solveLabels));
            }

            return o;
        }

        private static PrcNode ParseIParam(Dictionary<ulong, string> dictHashes, PrcNode parentNode, int index, ulong prmKey, IParam prmValue, bool solveLabels)
        {
            var prcNode = new PrcNode()
            {
                ParentNode = parentNode,
                ListIndex = index,
                TypeKey = prmValue.TypeKey,
                HashKeyValue = prmKey,
                HashKeyLabel = solveLabels && dictHashes.TryGetValue(prmKey, out string valueKeyLabel) ? valueKeyLabel : null,
            };

            if (prmValue.TypeKey == ParamType.list)
            {
                prcNode.Children = ((ParamList)prmValue).Nodes.Select((p, i) => ParseIParam(dictHashes, prcNode, i, 0, p, solveLabels)).ToList();
            }
            else if (prmValue.TypeKey == ParamType.@struct)
            {
                prcNode.Value = ParseStruct(dictHashes, prcNode, ((ParamStruct)prmValue).Nodes, solveLabels);
            }
            else if (prmValue.TypeKey == ParamType.hash40)
            {
                var valueHex = (ulong)(prmValue as ParamValue).Value;
                prcNode.Value = valueHex;
                prcNode.Hash40String = solveLabels && dictHashes.TryGetValue(valueHex, out string valueLabel) ? valueLabel : null;
            }
            else
            {
                prcNode.Value = (prmValue as ParamValue).Value;
            }

            return prcNode;
        }
    }

    public class PrcStruct
    {
        public List<PrcNode> Nodes { get; set; }

        public List<PrcNode> GetAllNodes()
        {
            var o = new List<PrcNode>();

            foreach (var node in Nodes)
            {
                o.Add(node);

                switch (node.TypeKey)
                {
                    case ParamType.@struct:
                        o.AddRange(((PrcStruct)node.Value).GetAllNodes());
                        break;
                    case ParamType.list:
                        foreach (var nodeChild in node.Children)
                        {
                            o.Add(nodeChild);
                            if (nodeChild.TypeKey == ParamType.@struct)
                            {
                                o.AddRange(((PrcStruct)nodeChild.Value).GetAllNodes());
                            }
                        }
                        break;
                }
            }

            return o;
        }

        public List<string> GetAllLabels()
        {
            var allNodes = GetAllNodes();
            var o = new List<string>();

            foreach (var node in allNodes)
            {
                if (node.HashKeyLabel != null)
                    o.Add(node.HashKeyLabel);

                if (node.Hash40String != null)
                    o.Add(node.Hash40String);
            }

            return o.Distinct().ToList();
        }

        public List<ulong> GetAllHexes()
        {
            var allNodes = GetAllNodes();
            var o = new List<ulong>();

            foreach (var node in allNodes)
            {
                if (node.HashKeyValue != 0)
                    o.Add(node.HashKeyValue);

                if (node.TypeKey == ParamType.hash40)
                    o.Add((ulong)node.Value);
            }

            return o.Distinct().ToList();
        }
    }

    public class PrcNode
    {
        public PrcNode ParentNode { get; set; }

        public int ListIndex { get; set; }

        public ParamType TypeKey { get; set; }

        public ulong HashKeyValue { get; set; }

        public string HashKeyLabel { get; set; }

        public string HashKeyFormatted { get { return HashKeyLabel ?? $"0x{HashKeyValue:x10}"; } }

        public string Hash40String { get; set; }

        public object Value { get; set; }

        public string TypeKeyFormatted { get { return GetTypeKey(TypeKey); } }

        public string ValueFormatted
        {
            get
            {
                return
                    TypeKey == ParamType.hash40 ? Hash40String ?? $"0x{Value:x10}" :
                    TypeKey == ParamType.list ? $"{{{Children.Count} items}}" :
                    TypeKey == ParamType.@struct ? $"{{{((PrcStruct)Value).Nodes.Count} properties}}" :
                    Value?.ToString();
            }
        }

        public bool IsHash40Value
        {
            get { return TypeKey == ParamType.hash40; }
        }

        public List<PrcNode> Children { get; set; }

        public T GetValue<T>()
        {
            return (T)Value;
        }

        public string GetFullPath()
        {
            string path;
            if (ParentNode?.TypeKey == ParamType.list)
                path = ListIndex.ToString();
            else
                path = HashKeyFormatted;

            if (ParentNode != null)
                path = $"{ParentNode.GetFullPath()}/{path}";
            return path;
        }

        public override string ToString()
        {
            return $"{GetFullPath()}: {ValueFormatted} ({TypeKey})";
        }

        public PrcNode()
        {
            Children = new List<PrcNode>();
        }

        private static string GetTypeKey(ParamType paramType)
        {
            return paramType switch
            {
                ParamType.list => "List",
                ParamType.@sbyte => "SByte",
                ParamType.@ushort => "UShort",
                ParamType.@uint => "UInt",
                ParamType.@short => "Short",
                ParamType.@bool => "Bool",
                ParamType.@byte => "Byte",
                ParamType.@float => "Float",
                ParamType.hash40 => "Hash40",
                ParamType.@int => "Int",
                ParamType.@string => "String",
                ParamType.@struct => "Struct",
                _ => "Unknown",
            };
        }
    }
}
