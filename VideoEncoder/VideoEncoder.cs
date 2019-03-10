namespace VideoEncoder
{
    using System;
    using System.Threading.Tasks;
    
    internal class VideoEncoder
    {
        private const string EncodeErrorMessage = "An encoding error ocurred";

        private readonly Video video;

        internal EventHandler<VideoEventArgs> VideoEncoded;

        internal VideoEncoder(Video video) => this.video = video;

        internal async Task EncodeAsync()
        {
            try
            {
                Console.WriteLine($"Encoding.... Video {video.Name}");
                await SimulateEncodingAsync();
                OnVideoEncoded(Success.Yes);
            }
            catch
            {
                OnVideoEncoded(Success.No);
                throw;
            }
        }

        private async Task SimulateEncodingAsync()
        {
            var random = new Random();

            if (random.Next(1, 10) < 5)
                await Task.FromResult(0);
            else
                throw new Exception(EncodeErrorMessage);
        }

        protected virtual void OnVideoEncoded(Success success) =>
            VideoEncoded?.Invoke(this, new VideoEventArgs
            {
                Name = video.Name,
                Success = success
            });
    }
}
