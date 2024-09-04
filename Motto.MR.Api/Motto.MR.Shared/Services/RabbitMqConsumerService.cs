using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Motto.MR.Domain.Interfaces.Repositories;
using Motto.MR.Shared.Helper;
using Motto.MR.Shared.Models;
using System.Text;
using System.Text.Json;
using Serilog;

namespace Motto.MR.Shared.Services
{
    public class RabbitMqConsumerService : BackgroundService
    {
        readonly RabbitMQSettings _rabbitMQSettings;
        readonly IServiceScopeFactory _factory;
        readonly RabbitMqConsumer _consumer;

        public RabbitMqConsumerService(IServiceScopeFactory factory, RabbitMqConsumer consumer)
        {
            _factory = factory;
            _consumer = consumer;
            _rabbitMQSettings = ReadSettings.GetRabbitMQSettings();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            _consumer.AddListener(_rabbitMQSettings.Queue, (_, args) =>
            {
                using var scope = _factory.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<IMotorcycleRegisterLogRepository>();
                var body = args.Body.ToArray();
                var motorcycleJson = Encoding.UTF8.GetString(body);
                var motorcycle = JsonSerializer.Deserialize<Motorcycle>(motorcycleJson)!;

                if (motorcycle != null && motorcycle.Year == 2024)
                {
                    var motorcycleLog = new MotorcycleRegisterLog()
                    {
                        Identifier = motorcycle.Identifier,
                        Year = motorcycle.Year,
                        Model = motorcycle.Model,
                        LicensePlate = motorcycle.LicensePlate,
                    };

                    Log.Debug("RabbitMQ Listener");
                    if (motorcycleLog != null)
                    {
                        dbContext.Create(motorcycleLog);
                    }
                }
            });

            return Task.CompletedTask;
        }
    }
}
