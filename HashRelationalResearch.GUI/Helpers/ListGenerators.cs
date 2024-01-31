using HashRelationalResearch.GUI.Models;
using System.Linq;

namespace HashRelationalResearch.GUI.Helpers
{
    public static class ListGenerators
    {
        public static int[] GetIntegerList(int minValue, int maxValue)
        {
            return Enumerable.Range(minValue, maxValue).ToArray();
        }

        public static ListItem<int>[] GetIntegerListWithLabel(string label, int minValue, int maxValue)
        {
            return Enumerable.Range(minValue, maxValue).Select(p => new ListItem<int>($"{p} {label}", p)).ToArray();
        }
    }
}
