using System;

namespace VideoEncoder
{
    internal class VideoEventArgs : EventArgs
    {
        internal string Name { get; set; }
        internal Success Success { get; set; }
    }
}
