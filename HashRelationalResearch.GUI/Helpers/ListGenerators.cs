using HashRelationalResearch.GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HashRelationalResearch.GUI.Helpers
{
    public static class ListGenerators
    {
        public static int[] GetIntegerList(int minValue, int maxValue)
        {
            return Enumerable.Range(minValue, Math.Abs(maxValue - minValue) + 1).ToArray();
        }

        public static ListItem<int>[] GetIntegerListWithLabel(string label, int minValue, int maxValue)
        {
            return Enumerable.Range(minValue, Math.Abs(maxValue - minValue) + 1).Select(p => new ListItem<int>($"{p} {label}", p)).ToArray();
        }
    }
}
