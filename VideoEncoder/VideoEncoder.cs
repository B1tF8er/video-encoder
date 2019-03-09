using System;
using System.Threading.Tasks;

namespace VideoEncoder
{
    internal class VideoEncoder
    {
        internal EventHandler<VideoEventArgs> VideoEncoded;

        private readonly Video video;

        internal VideoEncoder(Video video) => this.video = video;

        internal async Task EncodeAsync()
        {
            Console.WriteLine($"Encoding.... Video {video.Name}");
            await Task.FromResult(0);
            OnVideoEncoded(Success.Yes);
        }

        protected virtual void OnVideoEncoded(Success success) =>
            VideoEncoded?.Invoke(this, new VideoEventArgs
            {
                Name = video.Name,
                Success = success
            });
    }
}
