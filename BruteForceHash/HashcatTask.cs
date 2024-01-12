using BruteForceHash.Helpers;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceHash
{
    public class HashcatTask
    {
        private bool _hashCatProcessDone = false;
        private readonly Logger _logger;
        private readonly Options _options;

        public HashcatTask(Logger logger, Options options)
        {
            _logger = logger;
            _options = options;
        }

        public void Run(string arguments, bool verbose = false)
        {
            Run(new List<string>() { arguments }, verbose, true);
        }

        public void RunWithWrapper(string arguments, bool monitor)
        {
            if (monitor)
                LaunchMonitoringTask();

            string arg = $"/c \"BruteForceHash.exe {Parser.Default.FormatCommandLine(_options)} | (cd \"{Path.GetDirectoryName(_options.PathHashCat)}\" && \"{Path.GetFileName(_options.PathHashCat)}\" {arguments}\")";

            _logger.Log("SLOWER!! DO NOT USE :(");
            if (monitor)
            {
                _logger.Log($"Launch hashcat: \"{_options.PathHashCat}\" {arguments}");
            }

            using (var process = new Process())
            {
                var processInfo = new ProcessStartInfo("cmd.exe");
                processInfo.Arguments = arg;
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = true;
                process.StartInfo = processInfo;
                process.Start();
                process.WaitForExit();
                process.Close();
            }

            _hashCatProcessDone = true;
        }

        public void Run(List<string> argumentsList, bool verbose, bool monitor)
        {
            if (monitor)
                LaunchMonitoringTask();

            // Launch HashCat
            foreach (var arguments in argumentsList)
            {
                if (verbose)
                    _logger.Log($"Running hashcat with arguments {arguments}.", false);

                using (var process = new Process())
                {
                    process.StartInfo.FileName = _options.PathHashCat;
                    process.StartInfo.WorkingDirectory = Path.GetDirectoryName(_options.PathHashCat);
                    process.StartInfo.Arguments = arguments;
                    process.StartInfo.CreateNoWindow = false;
                    process.Start();
                    process.WaitForExit();
                    process.Close();
                }
            }

            _hashCatProcessDone = true;
        }

        private void LaunchMonitoringTask()
        {
            var output = Path.Combine(Path.GetFullPath(_logger.PathFile).Replace(".txt", "_hashcat.txt"));

            Task.Run(async () =>
            {

                while (!_hashCatProcessDone)
                {
                    if (File.Exists(output))
                    {
                        var initialFileSize = new FileInfo(output).Length;
                        var lastReadLength = initialFileSize - 1024;
                        if (lastReadLength < 0) lastReadLength = 0;
                        while (!_hashCatProcessDone)
                        {
                            try
                            {
                                var fileSize = new FileInfo(output).Length;
                                if (fileSize > lastReadLength)
                                {
                                    using (var fs = new FileStream(output, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                                    {
                                        fs.Seek(lastReadLength, SeekOrigin.Begin);
                                        var buffer = new byte[1024];

                                        while (true)
                                        {
                                            var bytesRead = fs.Read(buffer, 0, buffer.Length);
                                            lastReadLength += bytesRead;

                                            if (bytesRead == 0)
                                                break;

                                            var text = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                                            if (!string.IsNullOrEmpty(text))
                                            {
                                                var textLines = text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                                                foreach (var line in textLines)
                                                {
                                                    _logger.LogResult($"{_options.Prefix}{line[(line.LastIndexOf(':') + 1)..].Trim()}{_options.Suffix}");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                _logger.Log(e.Message);
                            }
                            await Task.Delay(2000);
                        }
                    }
                    await Task.Delay(2000);
                }
            });
        }
    }
}
