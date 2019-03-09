using System;

namespace VideoEncoder
{
    internal class EmailService : ISender<string>
    {
        internal void OnVideoEncoded(object sender, VideoEventArgs ea) =>
            Send($"Sending email... Video {ea.Name} was encoded successfully? {ea.Success}");

        public void Send(string message) => Console.WriteLine(message);
    }
}
