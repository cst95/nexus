﻿using System.Net.Http;
using System.Threading.Tasks;
 using Nexus.Model.RiotApi;

namespace Nexus.RiotApi.Interfaces
{
    public interface IRiotApiClient 
    {
        Task<HttpResponseMessage> GetResponseAsync(Platform platform, Endpoint endpoint, string identifier, string apiKey);
    }
}