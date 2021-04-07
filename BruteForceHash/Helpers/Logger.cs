using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BruteForceHash.Helpers
{
    public class Logger : IDisposable
    {
        private readonly string _file;
        private readonly ConcurrentQueue<string> _queue;
        private readonly CancellationTokenSource _queueCts;
        private readonly ConsoleColor _defaultConsoleColor; 

        public string PathFile { get { return _file; } }

        public Logger(string file)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(file));
            _file = file;
            _queue = new ConcurrentQueue<string>();
            _queueCts = new CancellationTokenSource();
            _defaultConsoleColor = Console.ForegroundColor;

        }

        public void Init()
        {
            _ = Task.Run(async () =>
            {
                while (!_queueCts.IsCancellationRequested)
                {
                    var dequeueMessages = new List<string>();
                    while (_queue.TryDequeue(out string result))
                        dequeueMessages.Add(result);

                    if (dequeueMessages.Count > 0)
                        File.AppendAllLines(_file, dequeueMessages);

                    await Task.Delay(500);
                }
            });
        }

        public void Log(string line, bool saveInQueue = true)
        {
            Console.WriteLine($"{DateTime.Now.ToUniversalTime()} - {line}");
            if(saveInQueue)
                _queue.Enqueue(line);
        }

        public void LogResult(string line, bool saveInQueue = true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{DateTime.Now.ToUniversalTime()} - {line}");
            Console.ForegroundColor = _defaultConsoleColor;
            if (saveInQueue)
                _queue.Enqueue(line);
        }

        public void LogDiscret(string line)
        {
            _queue.Enqueue(line);
        }

        public void Dispose()
        {
            _queueCts.Cancel();
            _queueCts?.Dispose();
        }
    }
}
