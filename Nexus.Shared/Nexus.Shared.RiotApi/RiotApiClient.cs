using System.Net.Http;
using System.Threading.Tasks;
using Nexus.Shared.Models.RiotApi;
using Nexus.Shared.RiotApi.Interfaces;
using Nexus.Shared.Utility.Interfaces;

namespace Nexus.Shared.RiotApi
{
    public class RiotApiClient : IRiotApiClient
    {
        private readonly IUriBuilderService _uriService;
        private readonly IHttpClientFactory _httpClientFactory;

        public RiotApiClient(IHttpClientFactory httpClientFactory, IUriBuilderService uriService)
        {
            _httpClientFactory = httpClientFactory;
            _uriService = uriService;
        }

        public Task<HttpResponseMessage> GetResponseAsync(Platform platform, Endpoint endpoint, string identifier, string apiKey)
        {
            var pathForRequest = _uriService.GetUriForRequest(platform, endpoint, identifier, apiKey);
            var httpClient = _httpClientFactory.CreateClient();
            
            return httpClient.GetAsync(pathForRequest);
        }
    }
}