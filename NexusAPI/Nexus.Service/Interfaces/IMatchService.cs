using System.Threading.Tasks;
using Nexus.Model.Repository;
using Nexus.Model.RiotApi;
using Nexus.Model.RiotApi.Match;

namespace Nexus.Service.Interfaces
{
    public interface IMatchService
    {
        Task<RepositoryResponse<MatchlistDto>> GetMatchesByAccountIdAsync(Platform platform, string encryptedAccountId);
        Task<RepositoryResponse<MatchDto>> GetMatchByMatchIdAsync(Platform platform, string matchId);
    }
}