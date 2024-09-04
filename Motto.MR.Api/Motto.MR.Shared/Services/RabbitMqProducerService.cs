using Motto.MR.Shared.Helper;
using Motto.MR.Shared.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Motto.MR.Shared.Services
{
    public class RabbitMqProducerService
    {
        private readonly IConnection _connection;
        private readonly RabbitMQSettings _rabbitMQSettings;

        public RabbitMqProducerService()
        {
            _rabbitMQSettings = ReadSettings.GetRabbitMQSettings(); 
            var factory = new ConnectionFactory() { HostName = _rabbitMQSettings.DefaultConnection, Port = _rabbitMQSettings.Port };
            _connection = factory.CreateConnection();
        }

        public void SendMessage(object message)
        {
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: _rabbitMQSettings.Queue,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "",
                                     routingKey: _rabbitMQSettings.Queue,
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
