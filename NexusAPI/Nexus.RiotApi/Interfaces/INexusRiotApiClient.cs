using System.Threading.Tasks;
using Nexus.Model.Repository;
using Nexus.Model.RiotApi;

namespace Nexus.RiotApi.Interfaces
{
    public interface INexusRiotApiClient
    {
        Task<RepositoryResponse<T>> GetResponseAsync<T>(Platform platform, Endpoint endpoint, string identifier) where T: class;
    }
}