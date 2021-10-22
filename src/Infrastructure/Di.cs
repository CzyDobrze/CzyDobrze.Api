using CzyDobrze.Infrastructure.Common;
using CzyDobrze.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace CzyDobrze.Infrastructure
{
    public static class Di
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDateTimeService();
            services.AddPersistence();
            
            return services;
        }
    }
}