namespace VideoEncoder
{
    using System;

    internal class SmsService : ISender<Sms>, IFormatter<string, Sms>
    {
        internal void OnVideoEncoded(object sender, VideoEventArgs ea) =>
            Send(Format($"Sending sms... Video {ea.Name} was encoded successfully? {ea.Success}"));

        public void Send(Sms message) => Console.WriteLine(message.Body);

        public Sms Format(string message) =>
            new Sms
            {
                Body = message
            };
    }
}
