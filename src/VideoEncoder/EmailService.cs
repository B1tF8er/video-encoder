namespace VideoEncoder
{
    using System;

    internal class EmailService : ISender<Mail>, IFormatter<string, Mail>
    {
        internal void OnVideoEncoded(object sender, VideoEventArgs ea) =>
            Send(Format($"Video {ea.Name} was encoded successfully? {ea.Success}"));

        public void Send(Mail message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message.Body);
            Console.ResetColor();
        }

        public Mail Format(string message) => new Mail($"Sending email... {message}");
    }
}
