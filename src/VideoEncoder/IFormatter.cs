namespace VideoEncoder
{
    internal interface IFormatter<in TMessage, out TFormattedMessage>
    {
        TFormattedMessage Format(TMessage message);
    }
}
