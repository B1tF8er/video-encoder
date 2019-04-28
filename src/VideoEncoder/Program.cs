namespace VideoEncoder
{
    using System;
    using System.Threading.Tasks;
    using static ArgsParser;
    using static ConsoleExtensions;
    using static StringExtensions;

    class Program
    {
        private const string NoVideoNameParameter = "Need video name parameter";
        private const string AskForVideoName = "Please specify a video name:";

        static async Task Main(string[] args) =>
            await ValidateVideoNameAsync(args.TryGetVideoName());

        private static async Task ValidateVideoNameAsync(string videoName)
        {
            if (!videoName.IsNullOrEmptyOrWhiteSpace())
                await EncodeVideoAsync(videoName);
            else
                await AskForVideoNameAsync();
        }

        private static async Task AskForVideoNameAsync()
        {
            NoVideoNameParameter.WriteRedLine();
            AskForVideoName.WriteYellowLine();
            await ValidateVideoNameAsync(Console.ReadLine());
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

            videoEncoder.VideoEncoded -= emailService.OnVideoEncoded;
            videoEncoder.VideoEncoded -= smsService.OnVideoEncoded;
        }
    }
}
