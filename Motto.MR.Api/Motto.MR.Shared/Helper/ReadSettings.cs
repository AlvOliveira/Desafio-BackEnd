using Motto.MR.Shared.Models;

namespace Motto.MR.Shared.Helper
{
    public static class ReadSettings
    {
        public static RabbitMQSettings GetRabbitMQSettings()
        {
            var settings = new RabbitMQSettings();

            settings.DefaultConnection = Config.GetStr("RabbitMQ:DefaultConnection");
            settings.Port = int.Parse(Config.GetStr("RabbitMQ:Port"));
            settings.Queue = Config.GetStr("RabbitMQ:Queue");

            return settings;
        }

        public static JwtSettings GetJwtSettings()
        {
            var settings = new JwtSettings();

            settings.JwtKey = Config.GetStr("Jwt:JwtKey");

            return settings;
        }
    }
}
