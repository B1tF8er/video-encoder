namespace VideoEncoder
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static async Task Main(string[] args)
        {
            var name = TryGetVideoName(args);
            if (name != string.Empty)
                await EncodeVideoAsync(name);
            else
                Console.WriteLine("need name parameter");
        }

        private static string TryGetVideoName(string[] args)
        {
            if (args.Length == 1)
                return args[0];
            else
                return string.Empty;
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
