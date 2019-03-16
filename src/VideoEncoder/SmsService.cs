namespace VideoEncoder
{
    using System;

    internal class SmsService : ISmsService
    {
        internal void OnVideoEncoded(object sender, VideoEventArgs ea) =>
            Send(Format($"Video {ea.Name} was encoded successfully? {ea.Success}"));

        public Sms Format(string message) => new Sms($"Sending sms... {message}");

        public void Send(Sms message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message.Body);
            Console.ResetColor();
        }
    }
}
