using Microsoft.EntityFrameworkCore;
using Motto.MR.DataAccess.Contexts;
using Motto.MR.DataAccess.Repositories;
using Motto.MR.Domain.Handler;
using Motto.MR.Domain.Interfaces.Repositories;
using Motto.MR.Shared.Helper;
using Motto.MR.Shared.Services;
using RabbitMQ.Client;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

ConfigureLog();

// Add services to the container.
ConfigureServices(builder);

builder.Services.AddControllers();

var rbbtMqSet = ReadSettings.GetRabbitMQSettings();

builder.Services.AddSingleton(
    new ConnectionFactory
    {
        HostName = rbbtMqSet.DefaultConnection,
        Port = rbbtMqSet.Port
    });

builder.Services.AddSingleton<RabbitMqConsumer>();
builder.Services.AddHostedService<RabbitMqConsumerService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void ConfigureServices(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    builder.Services.AddDbContext<MottoMRContext>(options => options.UseNpgsql(connectionString));
    
    builder.Services.AddTransient<IMotorcycleRepository, MotorcycleRepository>();
    builder.Services.AddTransient<MotorcycleHandler, MotorcycleHandler>();

    builder.Services.AddTransient<IDeliveryPersonRepository, DeliveryPersonRepository>();
    builder.Services.AddTransient<DeliveryPersonHandler, DeliveryPersonHandler>();

    builder.Services.AddTransient<IRentalRepository, RentalRepository>();
    builder.Services.AddTransient<RentalHandler, RentalHandler>();

    builder.Services.AddTransient<IMotorcycleRegisterLogRepository, MotorcycleRegisterLogRepository>();
    builder.Services.AddTransient<MotorcycleRegisterLogHandler, MotorcycleRegisterLogHandler>();
}

void ConfigureLog()
{
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
        .Build();

    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .CreateLogger();
}