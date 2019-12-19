using System.Threading.Tasks;
using Nexus.Model.Repository;
using Nexus.Model.RiotApi;
using Nexus.Model.RiotApi.Match;
using Nexus.Repository.Interfaces;
using Nexus.Service.Interfaces;

namespace Nexus.Service
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;

        public MatchService(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }
        
        public Task<RepositoryResponse<MatchlistDto>> GetMatchesByAccountIdAsync(Platform platform, string encryptedAccountId)
        {
            return _matchRepository.GetMatchesByAccountIdAsync(platform, encryptedAccountId);
        }

        public Task<RepositoryResponse<MatchDto>> GetMatchByMatchIdAsync(Platform platform, string matchId)
        {
            return _matchRepository.GetMatchByIdAsync(platform, matchId);
        }
    }
}