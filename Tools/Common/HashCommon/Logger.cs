using System;

namespace HashCommon
{
    public static class Logger
    {
        private readonly static ConsoleColor _defaultConsoleColor = ConsoleColor.Gray;

        public static void LogInformation(string message, bool resetLine = false)
        {
            if (resetLine)
                ClearPreviousConsoleLine();
            Console.WriteLine($"${DateTime.Now} - {message}");
        }

        public static void LogSuccess(string message, bool resetLine = false)
        {
            if (resetLine)
                ClearPreviousConsoleLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"${DateTime.Now} - {message}");
            Console.ForegroundColor = _defaultConsoleColor;
        }

        public static void LogError(string message, bool resetLine = false)
        {
            if (resetLine)
                ClearPreviousConsoleLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"${DateTime.Now} - {message}");
            Console.ForegroundColor = _defaultConsoleColor;
        }

        public static void ClearPreviousConsoleLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
