using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HashRelationalResearch.GUI.Services.Interfaces
{
    public interface IConfigurationService
    {
        string HashDBFilePath { get; set; }
        string HashcatPath { get; set; }
        string PrcRootPath { get; set; }

        string[] GetExcludePatterns();
        string[] GetIncludePatterns();

        void SaveGlobalConfiguration();
    }
}
