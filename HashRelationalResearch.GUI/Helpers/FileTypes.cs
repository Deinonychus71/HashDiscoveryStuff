using System;

namespace HashRelationalResearch.GUI.Helpers
{
    [Flags]
    public enum FileTypes
    {
        None = 0,
        All = 1,
        Json = 2,
        Hbt = 4,
        Exe = 8,
        Bin = 16
    }
}
