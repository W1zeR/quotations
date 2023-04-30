namespace RabbitMQ
{
    public delegate Task OnDataReceiveEvent<T>(T data);

    public interface IRabbitMQ
    {
        void Subscribe<T>(string queueName, OnDataReceiveEvent<T> onReceive);
        void Push<T>(string queueName, T data);
    }
}
