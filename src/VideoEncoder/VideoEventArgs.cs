namespace VideoEncoder
{
    using System;
    
    internal class VideoEventArgs : EventArgs
    {
        internal string Name { get; set; }
        internal Success Success { get; set; }
    }
}
