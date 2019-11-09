using System.Threading.Tasks;
using Summoner.Models.RiotApi;

namespace Summoner.Service
{
    public interface ISummonerService
    {
        Task<RepositoryResponse<SummonerDto>> GetSummonerByName(Platform platform, string summonerName);
    }
}