using System.Collections.Generic;

namespace BruteForceHash.GUI.Services.Interfaces
{
    public interface IBlacklistService
    {
        HashSet<string> Blacklist { get; }

        void AddToBlackList(string? hash40);
    }
}
