using System.Threading.Tasks;
using Nexus.Model.Repository;
using Nexus.Model.RiotApi;
using Nexus.Model.RiotApi.Summoner;

namespace Nexus.Service.Interfaces
{
    public interface ISummonerService
    {
        Task<RepositoryResponse<SummonerDto>> GetSummonerByNameAsync(Platform platform, string summonerName);
    }
}