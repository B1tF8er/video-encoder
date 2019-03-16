namespace VideoEncoder
{
    public interface IEmailService : IFormatter<string, Mail>, ISender<Mail>
    {
        
    }
}