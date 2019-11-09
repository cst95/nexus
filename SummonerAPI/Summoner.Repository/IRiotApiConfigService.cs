using System;
using Summoner.Models.RiotApi;

namespace Summoner.Repository
{
    public interface IRiotApiConfigService
    {
        string GetPlatformRoute(Platform platform);
        string GetEndpointPath(Endpoint endpoint);
    }
}