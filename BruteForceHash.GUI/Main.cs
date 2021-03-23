using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BruteForceHash.GUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            cbMethod.SelectedIndex = 0;
            cbNbThreads.SelectedIndex = 7;
            cbWordsLimit.SelectedIndex = 2;

            var allDictionaries = Directory.GetFiles("Dictionaries", "*.dic");
            foreach (var dictionaryPath in allDictionaries)
            {
                chklDictionaries.Items.Add(Path.GetFileNameWithoutExtension(dictionaryPath));
;            }
        }
    }
}
