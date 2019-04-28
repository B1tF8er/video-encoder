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

        static async Task Main(string[] args)
        {
            var videoName = args.TryGetVideoName();
            await ValidateVideoNameAsync(videoName);
        }

        static async Task ValidateVideoNameAsync(string videoName)
        {
            if (!videoName.IsNullOrEmptyOrWhiteSpace())
                await EncodeVideoAsync(videoName);
            else
            {
                NoVideoNameParameter.WriteRedLine();
                AskForVideoName.WriteYellowLine();
                videoName = Console.ReadLine();
                await ValidateVideoNameAsync(videoName);
            }
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
