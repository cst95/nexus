using System;
using System.Collections.Specialized;
using System.IO;
using Summoner.Models.RiotApi;

namespace Summoner.Repository
{
    public class RiotApiUriService : IRiotApiUriService
    {
        private readonly IRiotApiConfigService _riotApiConfigService;

        public RiotApiUriService(IRiotApiConfigService riotApiConfigService)
        {
            _riotApiConfigService = riotApiConfigService;
        }

        public Uri GetUriForRequest(Platform platform, Endpoint endpoint, string identifier, string apiKey)
        {
            var platformPath = _riotApiConfigService.GetPlatformRoute(platform);
            var endpointPath = _riotApiConfigService.GetEndpointPath(endpoint);
            var fullPath = Path.Combine(platformPath, endpointPath, identifier);

            var queryString = GetApiKeyQueryString(apiKey);
            
            var uri = new UriBuilder {Scheme = "https", Path = fullPath, Query = queryString };

            return uri.Uri;
        }

        private string GetApiKeyQueryString(string apiKey)
        {
            var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString["apiKey"] = apiKey;

            return queryString.ToString();
        }
        
        
    }
}