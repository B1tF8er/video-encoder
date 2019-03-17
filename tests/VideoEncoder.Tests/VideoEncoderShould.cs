namespace VideoEncoder.Tests
{
    using System;
    using Xunit;

    public class VideoEncoderShould
    {
        private const string videoName = "Test";
        private readonly VideoEncoder videoEncoder;

        public VideoEncoderShould()
        {
            var video = new Video
            {
                Name = videoName
            };
            videoEncoder = new VideoEncoder(video);
        }

        [Fact]
        public void RaiseEvent_ForEncodedVideo()
        {
            var success = Success.Yes;
            var expected = $"Video {videoName} was encoded successfully? {success}";

            EventHandler<VideoEventArgs> videoEncoded = (sender, ea) => {
                var actual = $"Video {ea.Name} was encoded successfully? {ea.Success}";
                Assert.Equal(expected, actual);
            };

            videoEncoder.VideoEncoded += videoEncoded;
            videoEncoder.OnVideoEncoded(success);
            videoEncoder.VideoEncoded -= videoEncoded;
        }

        [Fact]
        public void RaiseEvent_ForUnencodedVideo()
        {
            var success = Success.No;
            var expected = $"Video {videoName} was encoded successfully? {success}";

            EventHandler<VideoEventArgs> videoEncoded = (sender, ea) => {
                var actual = $"Video {ea.Name} was encoded successfully? {ea.Success}";
                Assert.Equal(expected, actual);
            };

            videoEncoder.VideoEncoded += videoEncoded;
            videoEncoder.OnVideoEncoded(success);
            videoEncoder.VideoEncoded -= videoEncoded;
        }
    }
}