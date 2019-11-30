using System;
using System.IO;
using Nexus.Shared.Models.RiotApi;
using Nexus.Shared.Utility.Interfaces;

namespace Nexus.Shared.Utility
{
    public class UriBuilderService : IUriBuilderService
    {
        private readonly IRiotApiConfigRepository _riotApiConfigRepository;

        public UriBuilderService(IRiotApiConfigRepository riotApiConfigRepository)
        {
            _riotApiConfigRepository = riotApiConfigRepository;
        }

        public Uri GetUriForRequest(Platform platform, Endpoint endpoint, string identifier, string apiKey)
        {
            var platformPath = _riotApiConfigRepository.GetPlatformRoute(platform);
            var endpointPath = _riotApiConfigRepository.GetEndpointPath(endpoint);
            var fullPath = Path.Combine(endpointPath, identifier);

            var queryString = GetApiKeyQueryString(apiKey);
            
            var uri = new UriBuilder {Scheme = "https", Host = platformPath, Port = -1, Path = fullPath, Query = queryString };

            return uri.Uri;
        }

        private string GetApiKeyQueryString(string apiKey)
        {
            var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString["api_key"] = apiKey;

            return queryString.ToString();
        }
    }
}