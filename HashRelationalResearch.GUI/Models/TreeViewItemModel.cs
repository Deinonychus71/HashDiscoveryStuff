using System.Collections.Generic;

namespace HashRelationalResearch.GUI.Models
{
    public class TreeViewItemModel : ObservableModelBase
    {
        #region Members
        private bool? _isChecked = false;
        private bool _isExpanded = false;
        private readonly TreeViewItemModel? _parent;
        #endregion

        #region Properties
        public List<TreeViewItemModel> Children { get; } = [];
        public bool IsInitiallySelected { get; private set; }
        public string Key { get; private set; }
        public string? FullPathName { get; private set; }
        public string Name { get; private set; }
        public bool? IsChecked
        {
            get { return _isChecked; }
            set { this.SetIsChecked(value, true, true); }
        }
        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                _isExpanded = value;
                OnPropertyChanged(nameof(IsExpanded));
            }
        }

        public bool HasChildren { get { return Children.Count > 0; } }
        #endregion

        public TreeViewItemModel(TreeViewItemModel? parent, string key, string name, string? fullPathName = null)
        {
            _parent = parent;
            Key = key;
            Name = name;
            FullPathName = fullPathName;
        }

        private void SetIsChecked(bool? value, bool updateChildren, bool updateParent)
        {
            if (value == _isChecked)
                return;

            _isChecked = value;

            if (updateChildren && _isChecked.HasValue)
                this.Children.ForEach(c => c.SetIsChecked(_isChecked, true, false));

            if (updateParent && _parent != null)
                _parent.VerifyCheckState();

            this.OnPropertyChanged("IsChecked");
        }

        private void VerifyCheckState()
        {
            bool? state = null;
            for (int i = 0; i < this.Children.Count; ++i)
            {
                bool? current = this.Children[i].IsChecked;
                if (i == 0)
                {
                    state = current;
                }
                else if (state != current)
                {
                    state = null;
                    break;
                }
            }
            this.SetIsChecked(state, false, true);
        }
    }
}
