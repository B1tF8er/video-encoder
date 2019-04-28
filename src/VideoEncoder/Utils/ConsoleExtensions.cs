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

        internal static void WriteRedLine(this string message) =>
            WriteLine(message, ConsoleColor.Red);

        internal static void WriteGreenLine(this string message) =>
            WriteLine(message, ConsoleColor.Green);

        internal static void WriteCyanLine(this string message) =>
            WriteLine(message, ConsoleColor.Cyan);

        internal static void WriteMagentaLine(this string message) =>
            WriteLine(message, ConsoleColor.Magenta);
    }
}
