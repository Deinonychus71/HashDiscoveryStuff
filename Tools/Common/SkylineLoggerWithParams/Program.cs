using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SkylineLoggerWithParams
{
    class Program
    {
        private const int DefaultIpPort = 6969;

        private static string IpAddress;
        private static int IpPort;

        static void Main(string[] args)
        {
            if (args.Length > 2)
            {
                IpAddress = args[0];
                _ = int.TryParse(args[1], out int IpPort);
            }
            else
            {
                Console.WriteLine("Enter Switch's IP Address:");
                IpAddress = Console.ReadLine().Trim();
                Console.WriteLine("Enter Port Number (Leave Blank for Default (6969)):");
                _ = int.TryParse(Console.ReadLine().Trim(), out int IpPort);
            }

            if (IpPort == 0)
                IpPort = DefaultIpPort;

            var s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            while (true)
            {
                try
                {
                    s.Connect(IpAddress, IpPort);
                    Console.WriteLine("Socket Connection Success!");

                    var incompleteLastLine = string.Empty;
                    while (true)
                    {
                        var buffer = new byte[1024];
                        try
                        {
                            var data = s.Receive(buffer, SocketFlags.None);
                            if (data > 0)
                            {
                                var str = $"{incompleteLastLine}{Encoding.UTF8.GetString(buffer)}";
                                incompleteLastLine = string.Empty;
                                var strLines = str.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                                var savedStrLines = new List<string>();
                                for (int i = 0; i < strLines.Length; i++)
                                {
                                    if (i == strLines.Length - 1 && !string.IsNullOrWhiteSpace(strLines[i].Trim('\0')))
                                    {
                                        incompleteLastLine = strLines[i];
                                    }
                                    else if (!strLines[i].StartsWith("[ResInflateThread"))
                                    {
                                        savedStrLines.Add(strLines[i]);
                                    }
                                }
                                Console.Write(string.Join('\n', savedStrLines));
                            }
                        }
                        catch
                        {
                            break;
                        }
                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine("Couldn't connect to socket! Trying again in 5 seconds.");
                    Console.WriteLine(e.Message);
                    Thread.Sleep(5000);
                }
                catch
                {
                    Thread.Sleep(5000);
                }
            }
        }
    }
}