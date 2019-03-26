namespace VideoEncoder
{
    using System;
    using System.Threading.Tasks;
    using static ArgsParser;
    using static ConsoleExtensions;

    class Program
    {
        private const string NoVideoNameParameter = "Need video name parameter";

        static async Task Main(string[] args)
        {
            var name = args.TryGetVideoName();
            if (name != string.Empty)
                await EncodeVideoAsync(name);
            else
                NoVideoNameParameter.WriteLine(ConsoleColor.Red);
        }

        private static async Task EncodeVideoAsync(string videoName)
        {
            var video = new Video { Name = videoName };
            var videoEncoder = new VideoEncoder(video);
            var emailService = new EmailService();
            var smsService = new SmsService();

            videoEncoder.VideoEncoded += emailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += smsService.OnVideoEncoded;

            await videoEncoder.EncodeAsync();
        }
    }
}
