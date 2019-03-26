namespace VideoEncoder
{
    using System;
    using static ConsoleExtensions;

    public class EmailService : IEmailService
    {
        internal void OnVideoEncoded(object sender, VideoEventArgs ea) =>
            Send(Format($"Video {ea.Name} was encoded successfully? {ea.Success}"));

        public Mail Format(string message) => new Mail($"Sending email... {message}");

        public void Send(Mail message) => 
            message.Body.WriteLine(ConsoleColor.Cyan);
    }
}
