using System;

namespace BruteForceHash.GUI.Helpers
{
    public class Hash40EventArgs : EventArgs
    {
        public string Hash40
        {
            get;
            private set;
        }

        public Hash40EventArgs(string hash40)
        {
            Hash40 = hash40;
        }

    }
}
