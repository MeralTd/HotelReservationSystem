namespace Service;

public interface IMessageProducer
{
    public void SendingMessage<T>(T message);

}
