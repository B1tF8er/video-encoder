namespace VideoEncoder
{
    using System;

    internal static class ConsoleExtensions
    {
        internal static void WriteLine(this string message, ConsoleColor consoleColor = ConsoleColor.White)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
