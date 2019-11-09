﻿using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Summoner.Models.RiotApi;

namespace Summoner.Repository
{
    public class RiotApiClient : IRiotApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IRiotApiUriService _uriService;
        private readonly string _apiKey;

        public RiotApiClient(HttpClient httpClient, IRiotApiUriService uriService, IConfiguration config)
        {
            _httpClient = httpClient;
            _uriService = uriService;
            _apiKey = config["APIKEY"];
        }

        public Task<HttpResponseMessage> GetSummonerAsync(Platform platform, Endpoint endpoint, string identifier)
        {
            var pathForRequest = _uriService.GetUriForRequest(platform, endpoint, identifier, _apiKey);

            return _httpClient.GetAsync(pathForRequest);
        }
    }
}