using Microsoft.Extensions.Configuration;

namespace BillBuddy.Core.Services
{
    public interface IConfigService
    {
        public IConfigurationRoot Config { get; }
    }

    public class ConfigService : IConfigService
    {
        public IConfigurationRoot Config { get; }

        public ConfigService()
        {
            Config = new ConfigurationBuilder()
            .AddJsonFile("AppConfig.json")
            .Build();
        }
    }
}
