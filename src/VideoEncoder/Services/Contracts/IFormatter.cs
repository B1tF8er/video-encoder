namespace VideoEncoder
{
    public interface IFormatter<in TMessage, out TFormattedMessage>
    {
        TFormattedMessage Format(TMessage message);
    }
}
