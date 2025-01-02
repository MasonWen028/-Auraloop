using System.Text.Json;


namespace NeteaseCloudMusicApi_SDK.Services
{
    public class ConfigurationService
    {
        private readonly Dictionary<string, string> _resourceTypeMap;
        private readonly AppConfiguration _appConfiguration;

        public ConfigurationService(string configFilePath)
        {
            if (string.IsNullOrEmpty(configFilePath) || !File.Exists(configFilePath))
            {
                throw new FileNotFoundException("Configuration file not found", configFilePath);
            }

            var configContent = File.ReadAllText(configFilePath);
            var configJson = JsonDocument.Parse(configContent).RootElement;

            _resourceTypeMap = ParseResourceTypeMap(configJson.GetProperty("resourceTypeMap"));
            _appConfiguration = ParseAppConfiguration(configJson.GetProperty("APP_CONF"));
        }

        /// <summary>
        /// Gets the resource type map.
        /// </summary>
        public Dictionary<string, string> GetResourceTypeMap()
        {
            return _resourceTypeMap;
        }

        /// <summary>
        /// Gets the application configuration.
        /// </summary>
        public AppConfiguration GetAppConfiguration()
        {
            return _appConfiguration;
        }

        /// <summary>
        /// Gets the API domain.
        /// </summary>
        public string GetApiDomain()
        {
            return _appConfiguration.ApiDomain;
        }

        /// <summary>
        /// Gets the domain.
        /// </summary>
        public string GetDomain()
        {
            return _appConfiguration.Domain;
        }

        /// <summary>
        /// Checks if encryption is enabled.
        /// </summary>
        public bool IsEncryptionEnabled()
        {
            return _appConfiguration.Encrypt;
        }

        /// <summary>
        /// Parses the resource type map.
        /// </summary>
        private Dictionary<string, string> ParseResourceTypeMap(JsonElement resourceTypeMapJson)
        {
            var resourceTypeMap = new Dictionary<string, string>();

            foreach (var property in resourceTypeMapJson.EnumerateObject())
            {
                resourceTypeMap[property.Name] = property.Value.GetString();
            }

            return resourceTypeMap;
        }

        /// <summary>
        /// Parses the application configuration.
        /// </summary>
        private AppConfiguration ParseAppConfiguration(JsonElement appConfJson)
        {
            return new AppConfiguration
            {
                ApiDomain = appConfJson.GetProperty("apiDomain").GetString(),
                Domain = appConfJson.GetProperty("domain").GetString(),
                Encrypt = appConfJson.GetProperty("encrypt").GetBoolean(),
                EncryptResponse = appConfJson.GetProperty("encryptResponse").GetBoolean()
            };
        }
    }

    /// <summary>
    /// Represents application-specific configuration.
    /// </summary>
    public class AppConfiguration
    {
        public string? ApiDomain { get; set; }
        public string? Domain { get; set; }
        public bool Encrypt { get; set; }
        public bool EncryptResponse { get; set; }
    }
}

