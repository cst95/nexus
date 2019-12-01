using System.Threading.Tasks;
using Nexus.Model.Repository;
using Nexus.Model.RiotApi;
using Nexus.Repository.Interfaces;
using Nexus.Service.Interfaces;

namespace Nexus.Service
{
    public class SummonerService : ISummonerService
    {
        private readonly ISummonerRepository _summonerRepository;

        public SummonerService(ISummonerRepository summonerRepository)
        {
            _summonerRepository = summonerRepository;
        }

        public Task<RepositoryResponse<SummonerDto>> GetSummonerByNameAsync(Platform platform, string summonerName)
        {
            return _summonerRepository.GetSummonerByNameAsync(platform, summonerName);
        }
    }
}