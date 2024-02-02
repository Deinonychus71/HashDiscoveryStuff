using BruteForceHash.GUI.Services.Interfaces;
using HashCommon;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BruteForceHash.GUI.Services
{
    public class BlacklistService : IBlacklistService
    {
        private readonly IConfigurationService _configurationService;
        private readonly IHashDBService _hashDBService;
        private readonly HashSet<string> _blacklist;

        public HashSet<string> Blacklist { get { return [.. _blacklist]; } }

        public BlacklistService(IConfigurationService configurationService, IHashDBService hashDBService)
        {
            _configurationService = configurationService;
            _hashDBService = hashDBService;
            _blacklist = [];
            LoadBlacklist();
        }

        public void AddToBlackList(string? hash40)
        {
            if (!string.IsNullOrEmpty(hash40) && HashHelper.IsValidHash40Value(hash40))
            {
                _blacklist.Add(hash40);
                File.WriteAllLines(_configurationService.BlacklistFilePath, _blacklist.Select(p => p));
                _hashDBService.RemoveEntry(hash40);
            }
        }

        private void LoadBlacklist()
        {
            _blacklist.Clear();
            if (File.Exists(_configurationService.BlacklistFilePath))
            {
                foreach (var line in File.ReadAllLines(_configurationService.BlacklistFilePath))
                {
                    var hash40 = line.Trim();
                    if (HashHelper.IsValidHash40Value(hash40))
                    {
                        _blacklist.Add(hash40);
                        _hashDBService.RemoveEntry(hash40);
                    }
                }
            }
        }
    }
}
