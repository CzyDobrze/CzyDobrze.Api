using Microsoft.Extensions.DependencyInjection;

namespace CzyDobrze.Infrastructure.Persistence
{
    public static class Di
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            return services;
        }
    }
}