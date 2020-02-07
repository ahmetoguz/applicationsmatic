using Newtonsoft.Json;
using RabbitMQ.Client;
using Smatic.Core.Model;
using Smatic.Core.Services.RabbitQueue;
using System.Text;

namespace Smatic.Core.RabbitMQService
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly string _hostName = "localhost";
        public bool SendEmailToRabbitMQ(EmailModel emailModel)
        {
            var result = false;

            var factory = new ConnectionFactory()
            {
                HostName = _hostName,
            };

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "SmaticInviteChannel",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonConvert.SerializeObject(emailModel);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "SmaticInviteChannel",
                                     basicProperties: null,
                                     body: body);
            }

            result = true;
            return result;
        }
    }
}

