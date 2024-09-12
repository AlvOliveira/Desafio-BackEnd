using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Motto.MR.DataAccess.Contexts;
using Motto.MR.DataAccess.Repositories;
using Motto.MR.Domain.Handler;
using Motto.MR.Domain.Interfaces.Repositories;
using Motto.MR.Shared.Helper;
using Motto.MR.Shared.Services;
using RabbitMQ.Client;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configura a autenticação JWT
ConfigureAuthentication(builder);
ConfigureAuthorization(builder);
ConfigureSwagger(builder);
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
    Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();


void Migrate()
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<MottoMRContext>();

        try
        {
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            // Log error (ex)
            throw;
        }
    }
}


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

    builder.Services.AddTransient<IRentalPlanRepository, RentalPlanRepository>();
    builder.Services.AddTransient<RentalPlanHandler, RentalPlanHandler>();

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

void ConfigureSwagger(WebApplicationBuilder builder)
{
    builder.Services.AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            Description = "Standard authorization header using Bearer scheme (\"bearer {token}\")",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });

        options.OperationFilter<SecurityRequirementsOperationFilter>();
    });

}

void ConfigureAuthentication(WebApplicationBuilder builder)
{
    var jwtSet = ReadSettings.GetJwtSettings();
    var key = Encoding.ASCII.GetBytes(jwtSet.JwtKey);
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
}

void ConfigureAuthorization(WebApplicationBuilder builder)
{
    // Configura autorização
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
        options.AddPolicy("DeliveryPolicy", policy => policy.RequireRole("Delivery"));
    });
}