using System.Collections.Generic;
using Summoner.Models.RiotApi;

namespace Summoner.Repository
{
    public class RiotApiConfigService : IRiotApiConfigService
    {
        private readonly Dictionary<Platform, string> _platformRoutingValues = new Dictionary<Platform, string>()
        {
            {Platform.Br1, "br1.api.riotgames.com"},
            {Platform.Eun1, "eun1.api.riotgames.com"},
            {Platform.Euw1, "euw1.api.riotgames.com"},
            {Platform.Jp1, "jp1.api.riotgames.com"},
            {Platform.Kr, "kr.api.riotgames.com"},
            {Platform.La1, "la1.api.riotgames.com"},
            {Platform.La2, "la2.api.riotgames.com"},
            {Platform.Na1, "na1.api.riotgames.com"},
            {Platform.Oc1, "oc1.api.riotgames.com"},
            {Platform.Tr1, "tr1.api.riotgames.com"},
            {Platform.Ru, "ru.api.riotgames.com"}
        };

        private readonly Dictionary<Endpoint, string> _endpointPaths = new Dictionary<Endpoint,string>()
        {
            {Endpoint.GetSummonerByAccountId, "lol/summoner/v4/summoners/by-account"},
            {Endpoint.GetSummonerByName, "lol/summoner/v4/summoners/by-name"},
            {Endpoint.GetSummonerByPuuid, "lol/summoner/v4/summoners/by-puuid"},
            {Endpoint.GetSummonerBySummonerId, "lol/summoner/v4/summoners"},
        };

        public string GetPlatformRoute(Platform platform) => _platformRoutingValues.GetValueOrDefault(platform);

        public string GetEndpointPath(Endpoint endpoint) => _endpointPaths.GetValueOrDefault(endpoint);
    }
}
