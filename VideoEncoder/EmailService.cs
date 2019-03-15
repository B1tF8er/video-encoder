namespace VideoEncoder
{
    using System;

    internal class EmailService : ISender<Mail>, IFormatter<string, Mail>
    {
        internal void OnVideoEncoded(object sender, VideoEventArgs ea) =>
            Send(Format($"Sending email... Video {ea.Name} was encoded successfully? {ea.Success}"));

        public void Send(Mail message) => Console.WriteLine(message.Body);

        public Mail Format(string message) =>
            new Mail
            {
                Body = message
            };
    }
}
