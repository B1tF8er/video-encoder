namespace VideoEncoder
{
    using System;

    internal static class ArgsParser
    {
        internal static string TryGetVideoName(this string[] args) =>
            args.Length == 1 ? args[0] : string.Empty;
    }
}
