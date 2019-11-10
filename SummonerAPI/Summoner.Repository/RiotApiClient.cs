using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Summoner.Models.RiotApi;

namespace Summoner.Repository
{
    public class RiotApiClient : IRiotApiClient
    {
        private const string RiotApiKeyEnvVariableName = "RIOT_APIKEY";
        private readonly IRiotApiUriService _uriService;
        private readonly string _apiKey;
        private readonly IHttpClientFactory _httpClientFactory;

        public RiotApiClient(IHttpClientFactory httpClientFactory, IRiotApiUriService uriService, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _uriService = uriService;
            _apiKey = config[RiotApiKeyEnvVariableName];
        }

        public Task<HttpResponseMessage> GetSummonerAsync(Platform platform, Endpoint endpoint, string identifier)
        {
            var pathForRequest = _uriService.GetUriForRequest(platform, endpoint, identifier, _apiKey);
            var httpClient = _httpClientFactory.CreateClient();
            
            return httpClient.GetAsync(pathForRequest);
        }
    }
}