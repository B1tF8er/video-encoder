namespace VideoEncoder.Tests
{
    using System;
    using Xunit;

    public class VideoEncoderShould
    {
        private const string videoName = "Test";
        private readonly VideoEncoder sut;

        public VideoEncoderShould()
        {
            var video = new Video
            {
                Name = videoName
            };
            sut = new VideoEncoder(video);
        }

        [Fact]
        public void RaiseEvent_ForEncodedVideo()
        {
            var success = Success.Yes;
            var expected = $"Video {videoName} was encoded successfully? {success}";

            EventHandler<VideoEventArgs> onVideoEncoded = (sender, ea) => {
                var actual = $"Video {ea.Name} was encoded successfully? {ea.Success}";
                Assert.Equal(expected, actual);
            };

            sut.VideoEncoded += onVideoEncoded;
            sut.OnVideoEncoded(success);
            sut.VideoEncoded -= onVideoEncoded;
        }

        [Fact]
        public void RaiseEvent_ForUnencodedVideo()
        {
            var success = Success.No;
            var expected = $"Video {videoName} was encoded successfully? {success}";

            EventHandler<VideoEventArgs> onVideoEncoded = (sender, ea) => {
                var actual = $"Video {ea.Name} was encoded successfully? {ea.Success}";
                Assert.Equal(expected, actual);
            };

            sut.VideoEncoded += onVideoEncoded;
            sut.OnVideoEncoded(success);
            sut.VideoEncoded -= onVideoEncoded;
        }
    }
}