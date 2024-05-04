using Microsoft.Extensions.Configuration;

namespace JurDocs.ClientGenerator.Configurations
{
    internal sealed class AppSettings
    {
        private const string _appsettingFile = "appsettings.json";
        private ClientGeneratorSettings? _settings;

        public void InitConfig()
        {
            var configStart = new ConfigurationBuilder().AddJsonFile(_appsettingFile).Build();

            _settings = configStart.GetSection(ClientGeneratorSettings.sectionName).Get<ClientGeneratorSettings>();

            if (_settings == null)
                throw new Exception("Ошибка в конфигурационном файле.");

            if (!string.IsNullOrWhiteSpace(_settings?.AdditionalConfig))
            {
                configStart = new ConfigurationBuilder()
                    .AddJsonFile(_appsettingFile)
                    .AddJsonFile($"appsettings.{_settings.AdditionalConfig}.json")
                    .Build();

                _settings = configStart.GetSection(ClientGeneratorSettings.sectionName)
                                        .Get<ClientGeneratorSettings>();
            }

            _settings!.Validate();


        }

        public ClientGeneratorSettings Settings
        {
            get
            {
                if (_settings == null)
                    InitConfig();

                return _settings!;
            }
        }

    }
}