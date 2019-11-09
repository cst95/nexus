using System;
using Summoner.Models.RiotApi;

namespace Summoner.Repository
{
    public interface IRiotApiUriService
    {
        Uri GetUriForRequest(Platform platform, Endpoint endpoint, string identifier, string apiKey);
    }
}