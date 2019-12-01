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