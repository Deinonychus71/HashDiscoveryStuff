using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BruteForceHash.Helpers
{
    public class Logger : IDisposable
    {
        private readonly string _file;
        private readonly Queue<string> _queue;
        private readonly CancellationTokenSource _queueCts;

        public Logger(string file)
        {
            _file = file;
            _queue = new Queue<string>(10000);
            _queueCts = new CancellationTokenSource();
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

                    await Task.Delay(1000);
                }
            });
        }

        public void Log(string line, bool saveInQueue = true)
        {
            Console.WriteLine($"{DateTime.Now.ToUniversalTime()} - {line}");
            if(saveInQueue)
                _queue.Enqueue(line);
        }

        public void Dispose()
        {
            _queueCts.Cancel();
            _queueCts?.Dispose();
        }
    }
}
