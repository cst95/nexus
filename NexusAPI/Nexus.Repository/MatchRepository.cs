using System.Threading.Tasks;
using Nexus.Model.Repository;
using Nexus.Model.RiotApi;
using Nexus.Model.RiotApi.Match;
using Nexus.Repository.Interfaces;
using Nexus.RiotApi.Interfaces;

namespace Nexus.Repository
{
    public class MatchRepository : IMatchRepository
    {
        private readonly INexusRiotApiClient _nexusRiotApiClient;

        public MatchRepository(INexusRiotApiClient nexusRiotApiClient)
        {
            _nexusRiotApiClient = nexusRiotApiClient;
        }
        
        public Task<RepositoryResponse<MatchlistDto>> GetMatchesByAccountIdAsync(Platform platform, string encryptedAccountId)
        {
            return _nexusRiotApiClient.GetResponseAsync<MatchlistDto>(platform, Endpoint.GetMatchesByAccountId,
                encryptedAccountId);
        }

        public Task<RepositoryResponse<MatchDto>> GetMatchByIdAsync(Platform platform, string matchId)
        {
            return _nexusRiotApiClient.GetResponseAsync<MatchDto>(platform, Endpoint.GetMatchByMatchId, matchId);
        }
    }
}