using System.Threading.Tasks;
using Summoner.Models.RiotApi;

namespace Summoner.Repository
{
    public interface ISummonerRepository
    {
        Task<RepositoryResponse<SummonerDto>> GetSummonerByNameAsync(Platform platform, string summonerName);
    }
}