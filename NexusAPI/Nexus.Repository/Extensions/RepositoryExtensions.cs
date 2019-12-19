using Microsoft.Extensions.DependencyInjection;
using Nexus.Repository.Interfaces;

namespace Nexus.Repository.Extensions
{
    public static class RepositoryExtensions
    {
        public static void RegisterRepositoryExtensions(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISummonerRepository, SummonerRepository>();
            serviceCollection.AddTransient<IMatchRepository, MatchRepository>();
        }
    }
}