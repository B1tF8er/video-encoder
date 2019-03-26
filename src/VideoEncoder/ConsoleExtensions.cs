namespace VideoEncoder
{
    using System;

    public static class ConsoleExtensions
    {
        public static void WriteLine(this string message, ConsoleColor consoleColor = ConsoleColor.White)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
