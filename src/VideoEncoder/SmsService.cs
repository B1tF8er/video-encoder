namespace VideoEncoder
{
    using System;
    using static ConsoleExtensions;

    internal class SmsService : ISmsService
    {
        internal void OnVideoEncoded(object sender, VideoEventArgs ea) =>
            Send(Format($"Video {ea.Name} was encoded successfully? {ea.Success}"));

        public Sms Format(string message) => new Sms($"Sending sms... {message}");

        public void Send(Sms message) => 
            message.Body.WriteLine(ConsoleColor.Green);
    }
}
