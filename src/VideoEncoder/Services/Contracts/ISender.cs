namespace VideoEncoder
{
    public interface ISender<in TMessage>
    {
        void Send(TMessage message);
    }
}
