namespace VideoEncoder
{
    internal interface ISender<in TMessage>
    {
        void Send(TMessage message);
    }
}
