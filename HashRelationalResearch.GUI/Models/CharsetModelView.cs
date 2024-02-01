using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashRelationalResearch.GUI.Models
{
    public class CharsetModelView : ObservableModelBase
    {
        private bool _isChecked = false;

        public string Name { get; set; } = string.Empty;

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }
        }

        public string Value { get; set; } = string.Empty;
    }
}
