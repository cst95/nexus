using System.Threading.Tasks;
using Nexus.Model.Repository;
using Nexus.Model.RiotApi;

namespace Nexus.Repository.Interfaces
{
    public interface ISummonerRepository
    {
        Task<RepositoryResponse<SummonerDto>> GetSummonerByNameAsync(Platform platform,
            string summonerName);
    }
}