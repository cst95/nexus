using System.Threading.Tasks;
using Nexus.Model.Repository;
using Nexus.Model.RiotApi;
using Nexus.Model.RiotApi.Match;

namespace Nexus.Repository.Interfaces
{
    public interface IMatchRepository
    {
        Task<RepositoryResponse<MatchlistDto>> GetMatchesByAccountIdAsync(Platform platform, string encryptedAccountId);
    }
}