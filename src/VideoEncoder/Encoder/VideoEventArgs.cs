namespace VideoEncoder
{
    using System;
    
    public class VideoEventArgs : EventArgs
    {
        public string Name { get; set; }
        public Success Success { get; set; }
    }
}
