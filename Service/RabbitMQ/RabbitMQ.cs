using System.Text.Json;
using System.Text;
using RabbitMQ.Client.Exceptions;
using RabbitMQ.Client;
using Common.Settings;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Options;

namespace RabbitMQ
{
    public class RabbitMQ : IRabbitMQ, IDisposable
    {
        private readonly object connectionLock = new();
        private readonly RabbitMQSettings rabbitMQSettings;

        private IModel channel = null!;
        private IConnection connection = null!;

        public RabbitMQ(IOptions<RabbitMQSettings> settings)
        {
            rabbitMQSettings = settings.Value;
        }

        public void Dispose()
        {
            channel?.Close();
            connection?.Close();
            GC.SuppressFinalize(this);
        }

        private IModel GetChannel()
        {
            return channel;
        }

        private void RegisterListener(string queueName, EventHandler<BasicDeliverEventArgs> onReceive)
        {
            Connect();

            AddQueue(queueName);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += onReceive;

            channel.BasicConsume(queueName, false, consumer);
        }

        private void Publish<T>(string queueName, T data)
        {
            if (data == null)
            {
                return;
            }

            Connect();

            AddQueue(queueName);

            var json = JsonSerializer.Serialize<object>(data, new JsonSerializerOptions() { });

            var message = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(string.Empty, queueName, null, message);
        }

        private void Connect()
        {
            lock (connectionLock)
            {
                if (connection?.IsOpen ?? false)
                {
                    return;
                }

                var factory = new ConnectionFactory
                {
                    Uri = new Uri(rabbitMQSettings.Uri),
                    UserName = rabbitMQSettings.UserName,
                    Password = rabbitMQSettings.Password,

                    AutomaticRecoveryEnabled = true,
                    NetworkRecoveryInterval = TimeSpan.FromSeconds(5)
                };

                var retriesCount = 0;
                while (retriesCount < 15)
                {
                    try
                    {
                        connection ??= factory.CreateConnection();

                        if (channel == null)
                        {
                            channel = connection.CreateModel();
                            channel.BasicQos(0, 1, false);
                        }

                        break;
                    }
                    catch (BrokerUnreachableException)
                    {
                        Task.Delay(1000).Wait();

                        retriesCount++;
                    }
                }
            }
        }

        private void AddQueue(string queueName)
        {
            Connect();
            channel.QueueDeclare(queueName, true, false, false, null);
        }

        public void Subscribe<T>(string queueName, OnDataReceiveEvent<T> onReceive)
        {
            if (onReceive == null)
            {
                return;
            }

            RegisterListener(queueName, async (_, eventArgs) =>
            {
                var channel = GetChannel();
                try
                {
                    var message = Encoding.UTF8.GetString(eventArgs.Body.ToArray());

                    var obj = JsonSerializer.Deserialize<T>(message ?? "");

                    if (obj == null)
                    {
                        return;
                    }

                    await onReceive(obj);
                    channel.BasicAck(eventArgs.DeliveryTag, false);
                }
                catch
                {
                    channel.BasicNack(eventArgs.DeliveryTag, false, false);
                }
            });
        }

        public void Push<T>(string queueName, T data)
        {
            Publish(queueName, data);
        }
    }
}
