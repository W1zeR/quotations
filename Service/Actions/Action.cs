using Common.Settings;
using Mails.Models;
using Microsoft.Extensions.Options;
using RabbitMQ;

namespace Actions
{
    public class Action : IAction
    {
        private readonly IRabbitMQ rabbitMQ;
        private readonly RabbitMQSettings rabbitMQSettings;

        public Action(IRabbitMQ rabbitMQ, IOptions<RabbitMQSettings> settings)
        {
            this.rabbitMQ = rabbitMQ;
            rabbitMQSettings = settings.Value;

        }

        public void SendEmail(MailModel email)
        {
            rabbitMQ.Push(rabbitMQSettings.QueueName, email);
        }
    }
}
