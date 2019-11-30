using System;
using Summoner.Models.RiotApi;

namespace Summoner.Repository
{
    public interface IRiotApiConfigRepository
    {
        string GetPlatformRoute(Platform platform);
        string GetEndpointPath(Endpoint endpoint);
    }
}