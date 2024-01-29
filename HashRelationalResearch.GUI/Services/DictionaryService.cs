using HashRelationalResearch.GUI.Models;
using HashRelationalResearch.GUI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace HashRelationalResearch.GUI.Services
{
    public partial class DictionaryService : IDictionaryService
    {
        [GeneratedRegex(@"\[(.*?)\]", RegexOptions.Compiled)]
        private static partial Regex DictionaryFilesRegex();

        private readonly List<TreeViewItemModel> _treeViewData = [];

        public DictionaryService()
        {
            InitDictionariesInCache();
        }

        public List<TreeViewItemModel> GetDictionaries()
        {
            return GetDictionaries(_treeViewData);
        }

        public void RefreshDictionaries()
        {
            _treeViewData.Clear();
            InitDictionariesInCache();
        }

        private List<TreeViewItemModel> GetDictionaries(List<TreeViewItemModel> treeViewItems, TreeViewItemModel? parentTreeViewItem = null)
        {
            var output = new List<TreeViewItemModel>();
            foreach (var item in treeViewItems)
            {
                var newItem = new TreeViewItemModel(parentTreeViewItem, item.Key, item.Name, item.FullPathName);
                output.Add(newItem);
                if (item.Children.Count > 0)
                    newItem.Children.AddRange(GetDictionaries(item.Children, newItem));
            }
            return output;
        }

        private void InitDictionariesInCache()
        {
            var output = new List<TreeViewItemModel>();

            if (Directory.Exists("Dictionaries"))
            {
                //Retrieve all dictionary files
                var allDictionaries = Directory.GetFiles("Dictionaries", "*.dic", SearchOption.AllDirectories);

                //Enumerate
                foreach (var dictionaryPath in allDictionaries)
                {
                    var filename = Path.GetFileName(dictionaryPath);
                    var currentNodeCollection = _treeViewData;
                    TreeViewItemModel? parentNode = null;

                    //Path from Dictionary Names
                    var dictionaryFiles = DictionaryFilesRegex().Split(filename).Where(p => !string.IsNullOrEmpty(p)).ToArray();
                    var lastKey = string.Empty;

                    //Enumerator Directories in the Dictionary name
                    for (int i = 0; i < dictionaryFiles.Length; i++)
                    {
                        var last = i == dictionaryFiles.Length - 1;
                        var label = dictionaryFiles[i];
                        var key = $"{i}-{label}";

                        if (!last)
                        {
                            var currentNode = FindTreeItem(currentNodeCollection, key);
                            if (currentNode == null)
                            {
                                currentNode = new TreeViewItemModel(parentNode, key, $" -{label}-");
                                currentNodeCollection.Insert(currentNodeCollection.Where(p => p.Children.Count > 0).Count(), currentNode);
                            }
                            parentNode = currentNode;
                            currentNodeCollection = currentNode.Children;
                            continue;
                        }

                        if (last)
                        {
                            var nbrLines = File.ReadAllLines(dictionaryPath).Length;
                            var lastNode = new TreeViewItemModel(parentNode, key, $" {label.Replace(".dic", "", StringComparison.InvariantCultureIgnoreCase)} ~{nbrLines} words", dictionaryPath);
                            currentNodeCollection.Add(lastNode);
                        }
                    }
                }
            }
            else
            {
                Directory.CreateDirectory("Dictionaries");
            }
        }

        private TreeViewItemModel? FindTreeItem(IList<TreeViewItemModel> items, string key)
        {
            var output = items.FirstOrDefault(p => p.Key == key);
            if (output == null)
            {
                foreach (var item in items)
                {
                    if (item.Children.Count == 0)
                        continue;
                    output = FindTreeItem(item.Children, key);
                    if (output != null)
                        break;
                }
            }
            return output;
        }
    }
}
