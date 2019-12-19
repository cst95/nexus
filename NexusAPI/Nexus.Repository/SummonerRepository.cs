using System.Threading.Tasks;
using Nexus.Model.Repository;
using Nexus.Model.RiotApi;
using Nexus.Model.RiotApi.Summoner;
using Nexus.Repository.Interfaces;
using Nexus.RiotApi.Interfaces;

namespace Nexus.Repository
{
    public class SummonerRepository : ISummonerRepository
    {
        private readonly INexusRiotApiClient _nexusRiotApiClient;

        public SummonerRepository(INexusRiotApiClient nexusRiotApiClient)
        {
            _nexusRiotApiClient = nexusRiotApiClient;
        }

        public Task<RepositoryResponse<SummonerDto>> GetSummonerByNameAsync(Platform platform,
            string summonerName)
        {
            return _nexusRiotApiClient.GetResponseAsync<SummonerDto>(platform, Endpoint.GetSummonerByName, summonerName);
        }
    }
}