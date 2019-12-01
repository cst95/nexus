using Microsoft.Extensions.DependencyInjection;
using Nexus.Service.Interfaces;

namespace Nexus.Service.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterServiceDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISummonerService, SummonerService>();
        }
    }
}