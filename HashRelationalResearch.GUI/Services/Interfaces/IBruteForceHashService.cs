using HashRelationalResearch.GUI.Models;

namespace HashRelationalResearch.GUI.Services.Interfaces
{
    public interface IBruteForceHashService
    {
        string LastCommand { get; }

        bool StartProcess(HbtFile hbtFile, bool useHashCat);
    }
}
