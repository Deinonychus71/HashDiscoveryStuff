using BruteForceHash.GUI.Models;

namespace BruteForceHash.GUI.Services.Interfaces
{
    public interface IBruteForceHashService
    {
        string LastCommand { get; }

        bool StartProcess(HbtFile hbtFile, bool useHashCat);
    }
}
