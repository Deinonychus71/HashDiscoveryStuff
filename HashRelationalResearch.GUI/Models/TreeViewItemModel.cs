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
        public string? Value { get; private set; }
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

        public TreeViewItemModel(TreeViewItemModel? parent, string key, string name, string? value = null)
        {
            _parent = parent;
            Key = key;
            Name = name;
            Value = value;
        }

        public void UnselectAll()
        {
            var nodeQueue = new Queue<TreeViewItemModel>();
            nodeQueue.Enqueue(this);
            while (nodeQueue.Count != 0)
            {
                var item = nodeQueue.Dequeue();
                foreach (var child in item.Children)
                {
                    nodeQueue.Enqueue(child);
                }
                item.IsChecked = false;
            }
        }

        public void CheckValues(List<string> valuesToCheck)
        {
            var nodeQueue = new Queue<TreeViewItemModel>();
            nodeQueue.Enqueue(this);
            while (nodeQueue.Count != 0)
            {
                var item = nodeQueue.Dequeue();
                foreach (var child in item.Children)
                {
                    nodeQueue.Enqueue(child);
                }
                if (!string.IsNullOrEmpty(item.Value))
                    item.SetIsChecked(valuesToCheck.Contains(item.Value), false, true);
            }
        }

        public List<string> GetSelectedNodes()
        {
            var output = new List<string>();
            return GetSelectedNodes(ref output);
        }
        public List<string> GetSelectedNodes(ref List<string> output)
        {
            var nodeQueue = new Queue<TreeViewItemModel>();
            nodeQueue.Enqueue(this);
            while (nodeQueue.Count != 0)
            {
                var item = nodeQueue.Dequeue();
                foreach (var child in item.Children)
                {
                    nodeQueue.Enqueue(child);
                }
                if (item.IsChecked.HasValue && item.IsChecked.Value && !string.IsNullOrEmpty(item.Value))
                    output.Add(item.Value);
            }

            return output;
        }

        private void SetIsChecked(bool? value, bool updateChildren, bool updateParent)
        {
            if (value == _isChecked)
                return;

            _isChecked = value;

            if (updateChildren && _isChecked.HasValue)
                Children.ForEach(c => c.SetIsChecked(_isChecked, true, false));

            if (updateParent && _parent != null)
                _parent.VerifyCheckState();

            OnPropertyChanged(nameof(IsChecked));
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
