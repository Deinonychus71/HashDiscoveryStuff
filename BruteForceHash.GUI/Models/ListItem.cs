namespace BruteForceHash.GUI.Models
{
    public class ListItem<T>
    {
        public string Label { get; private set; }
        public T? Value { get; private set; }

        public ListItem(string label, T? value)
        {
            Label = label;
            Value = value;
        }
    }
}
