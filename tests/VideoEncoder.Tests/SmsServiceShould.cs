namespace VideoEncoder.Tests
{
    using System;
    using Xunit;
    using Moq;

    public class SmsServiceShould
    {
        private const string Message = "test";
        private readonly Mock<ISmsService> sut;

        public SmsServiceShould()
        {
            sut = new Mock<ISmsService>(MockBehavior.Strict);
        }

        [Fact]
        public void Format_Message_To_Sms()
        {
            var expected = new Sms(Message);
            sut.Setup(es => es.Format(Message)).Returns(expected);

            var actual = sut.Object.Format(Message);

            Assert.Equal(expected.Body, actual.Body);
        }

        [Fact]
        public void Send_Message_As_Sms()
        {
            var sms = new Sms(Message);
            sut.Setup(es => es.Send(sms));

            sut.Object.Send(sms);

            sut.Verify(es => es.Send(sms), Times.Once);
        }
    }
}
