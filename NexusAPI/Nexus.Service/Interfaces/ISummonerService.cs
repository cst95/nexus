using System.Threading.Tasks;
using Nexus.Model.Repository;
using Nexus.Model.RiotApi;

namespace Nexus.Service.Interfaces
{
    public interface ISummonerService
    {
        Task<RepositoryResponse<SummonerDto>> GetSummonerByNameAsync(Platform platform, string summonerName);
    }
}