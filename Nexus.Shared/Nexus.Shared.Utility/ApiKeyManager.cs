using Microsoft.Extensions.Configuration;
using Nexus.Shared.Utility.Interfaces;

namespace Nexus.Shared.Utility
{
    public class ApiKeyManager: IApiKeyManager
    {
        private const string RiotApiKeyEnvVariableName = "RIOT_APIKEY";
        private readonly string _apiKey;
  
        public ApiKeyManager(IConfiguration configuration)
        {
            _apiKey = configuration[RiotApiKeyEnvVariableName];
        }
           
        public string GetApiKeyFromEnvironmentVariable() => _apiKey;
    }
}