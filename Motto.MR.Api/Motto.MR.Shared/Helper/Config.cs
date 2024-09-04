using Microsoft.Extensions.Configuration;

namespace Motto.MR.Shared.Helper
{
    public static class Config
    {
        private static IConfiguration configuration;

        static Config()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
        }

        public static List<string> GetListStr(string key_Section)
        {
            var listStr = new List<string>(configuration.GetSection(key_Section/*"MachineRemoteConfiguration:Pins"*/)
                .GetChildren()
                .Select(x => x.Value));

            return listStr;
        }

        public static string GetStr(string key_Section)
        {
            var str = configuration.GetSection(key_Section/*"MachineRemoteConfiguration:Pins"*/).Value;

            return str;
        }
    }
}
