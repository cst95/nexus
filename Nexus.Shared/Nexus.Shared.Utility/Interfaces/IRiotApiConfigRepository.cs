using Nexus.Shared.Models.RiotApi;

namespace Nexus.Shared.Utility.Interfaces
{
    public interface IRiotApiConfigRepository
    {
        string GetPlatformRoute(Platform platform);
        string GetEndpointPath(Endpoint endpoint);
    }
}