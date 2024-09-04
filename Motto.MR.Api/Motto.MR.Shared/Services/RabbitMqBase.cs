using RabbitMQ.Client;

namespace Motto.MR.Shared.Services
{
    public abstract class RabbitMqBase
    {
        readonly IConnection _connection;
        protected readonly IModel Channel;

        protected RabbitMqBase(ConnectionFactory factory)
        {
            _connection = factory.CreateConnection();
            Channel = _connection.CreateModel();
        }

        protected void CreateQueueIfNotExists(string queueName)
        {
            Channel.QueueDeclare(queueName,
                durable: true,
                autoDelete: false, 
                exclusive: false, 
                arguments: new Dictionary<string, object>());
        }

        ~RabbitMqBase()
        {
            _connection.Dispose();
            Channel.Dispose();
        }
    }
}
