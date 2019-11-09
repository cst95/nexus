using System.Threading.Tasks;
using Summoner.Models.RiotApi;
using Summoner.Repository;

namespace Summoner.Service
{
    public class SummonerService : ISummonerService
    {
        private readonly IRiotApiSummonerRepository _summonerRepository;

        public SummonerService(IRiotApiSummonerRepository summonerRepository)
        {
            _summonerRepository = summonerRepository;
        }

        public Task<RepositoryResponse<SummonerDto>> GetSummonerByName(Platform platform, string summonerName)
        {
            return _summonerRepository.GetSummonerByNameAsync(platform, summonerName);
        }
    }
}