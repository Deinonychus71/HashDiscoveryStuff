using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HashRelationalResearch.GUI.Models
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
