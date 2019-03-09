using System;

namespace VideoEncoder
{
    internal class SmsService : ISender<string>
    {
        internal void OnVideoEncoded(object sender, VideoEventArgs ea) =>
            Send($"Sending sms... Video {ea.Name} was encoded successfully? {ea.Success}");

        public void Send(string message) => Console.WriteLine(message);
    }
}
