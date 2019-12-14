﻿using System.Net.Http;
using System.Threading.Tasks;
 using Nexus.Model.RiotApi;
 using Nexus.RiotApi.Interfaces;
 using Nexus.Utility.Interfaces;

 namespace Nexus.RiotApi
{
    public class RiotApiClient : IRiotApiClient
    {
        private readonly IUriBuilderService _uriService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiKey;

        public RiotApiClient(IHttpClientFactory httpClientFactory, IUriBuilderService uriService, IApiKeyManager apiKeyManager)
        {
            _httpClientFactory = httpClientFactory;
            _uriService = uriService;
            _apiKey = apiKeyManager.GetApiKeyFromEnvironmentVariable();
        }

        public Task<HttpResponseMessage> GetResponseAsync(Platform platform, Endpoint endpoint, string identifier)
        {
            var pathForRequest = _uriService.GetUriForRequest(platform, endpoint, identifier, _apiKey);
            var httpClient = _httpClientFactory.CreateClient();
            
            return httpClient.GetAsync(pathForRequest);
        }
    }
}