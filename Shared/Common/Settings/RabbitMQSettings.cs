namespace Common.Settings
{
    public class RabbitMQSettings
    {
        public string Uri { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string QueueName { get; set; } = null!;
    }
}
