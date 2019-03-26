namespace VideoEncoder
{
    using System;
    using System.Threading.Tasks;
    using static ConsoleExtensions;

    public class VideoEncoder
    {
        private readonly Video video;

        public EventHandler<VideoEventArgs> VideoEncoded;

        public VideoEncoder(Video video) => this.video = video;

        public async Task EncodeAsync()
        {
            $"Encoding.... Video {video.Name}".WriteLine(ConsoleColor.Magenta);
            var success = await SimulateEncodingAsync();
            OnVideoEncoded(success);
        }

        private async Task<Success> SimulateEncodingAsync()
        {
            var random = new Random();

            if (random.Next(1, 10) < 5)
                return await Task.FromResult(Success.Yes);
            else
                return await Task.FromResult(Success.No);
        }

        public virtual void OnVideoEncoded(Success success) =>
            VideoEncoded?.Invoke(this, new VideoEventArgs
            {
                Name = video.Name,
                Success = success
            });
    }
}
