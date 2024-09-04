using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Motto.MR.Shared.Services
{
    public class RabbitMqConsumer : RabbitMqBase
    {
        readonly EventingBasicConsumer _consumer;

        public RabbitMqConsumer(ConnectionFactory factory) : base(factory)
        {
            _consumer = new EventingBasicConsumer(Channel);
        }

        public void AddListener(string queueName, EventHandler<BasicDeliverEventArgs> handler)
        {
            _consumer.Received += handler;
            CreateQueueIfNotExists(queueName);
            Channel.BasicConsume(queue: queueName,
                autoAck: true,
                consumer: _consumer,
                noLocal: false,
                exclusive: false,
                consumerTag: Guid.NewGuid().ToString(),
                arguments: new Dictionary<string, object>());
        }

        public void RemoveListener(EventHandler<BasicDeliverEventArgs> handler)
        {
            _consumer.Received -= handler;
        }
    }
}
