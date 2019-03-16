namespace VideoEncoder.Tests
{
    using System;
    using Xunit;
    using Moq;

    public class EmailServiceShould
    {
        private const string Message = "test";
        private readonly Mock<IEmailService> sut;

        public EmailServiceShould()
        {
            sut = new Mock<IEmailService>(MockBehavior.Strict);
        }

        [Fact]
        public void Format_Message_To_Mail()
        {
            var expected = new Mail(Message);
            sut.Setup(es => es.Format(Message)).Returns(expected);

            var actual = sut.Object.Format(Message);

            Assert.Equal(expected.Body, actual.Body);
        }

        [Fact]
        public void Send_Message_As_Mail()
        {
            var mail = new Mail(Message);
            sut.Setup(es => es.Send(mail));

            sut.Object.Send(mail);

            sut.Verify(es => es.Send(mail), Times.Once);
        }
    }
}
