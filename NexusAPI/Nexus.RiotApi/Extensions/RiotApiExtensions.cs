using Microsoft.Extensions.DependencyInjection;
using Nexus.RiotApi.Interfaces;

namespace Nexus.RiotApi.Extensions
{
    public static class RiotApiExtensions
    {
        public static void RegisterRiotApiDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRiotApiClient, RiotApiClient>();
            serviceCollection.AddTransient<INexusRiotApiClient, NexusRiotApiClient>();
        }
    }
}