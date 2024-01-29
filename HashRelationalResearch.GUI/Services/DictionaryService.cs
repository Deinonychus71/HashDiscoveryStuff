using HashRelationalResearch.GUI.Models;
using HashRelationalResearch.GUI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HashRelationalResearch.GUI.Services
{
    public partial class DictionaryService : IDictionaryService
    {
        [GeneratedRegex(@"\[(.*?)\]", RegexOptions.Compiled)]
        private static partial Regex DictionaryFilesRegex();

        public ObservableCollection<TreeViewItem> LoadDictionaries()
        {
            var output = new ObservableCollection<TreeViewItem>();

            if (Directory.Exists("Dictionaries"))
            {
                //Retrieve all dictionary files
                var allDictionaries = Directory.GetFiles("Dictionaries", "*.dic", SearchOption.AllDirectories);

                //Enumerate
                foreach (var dictionaryPath in allDictionaries)
                {
                    var filename = Path.GetFileName(dictionaryPath);
                    var currentNodeCollection = output;

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
                                currentNode = new TreeViewItem(key, $" -{label}-");
                                currentNodeCollection.Add(currentNode);
                            }
                            currentNodeCollection = currentNode.Children;
                            continue;
                        }

                        if (last)
                        {
                            var nbrLines = File.ReadAllLines(dictionaryPath).Length;
                            var lastNode = new TreeViewItem(key, $" {label.Replace(".dic", "", StringComparison.InvariantCultureIgnoreCase)} ~{nbrLines} words");
                            lastNode.FullPathName = dictionaryPath;
                            currentNodeCollection.Add(lastNode);
                        }
                    }
                }
            }
            else
            {
                Directory.CreateDirectory("Dictionaries");
            }

            return output;
        }

        private TreeViewItem? FindTreeItem(ObservableCollection<TreeViewItem> items, string key)
        {
            var output = items.FirstOrDefault(p => p.Key == key);
            if(output == null)
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
