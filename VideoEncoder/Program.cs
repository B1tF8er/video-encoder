using System;
using System.Threading.Tasks;

namespace VideoEncoder
{
    class Program
    {
        private const string ErrorMessage = "Only one arg is allowed";

        static async Task Main(string[] args)
        {
            try
            {
                await EncodeVideoAsync(TryGetVideoName(args));
            }
            catch (InvalidOperationException ioe)
            {
                Environment.FailFast(ioe.Message, ioe);
            }
            catch (Exception e)
            {
                Environment.FailFast(e.Message, e);
            }
        }

        private static string TryGetVideoName(string[] args)
        {
            if (args.Length == 1)
                return args[0];
            else
                throw new InvalidOperationException(ErrorMessage);
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
