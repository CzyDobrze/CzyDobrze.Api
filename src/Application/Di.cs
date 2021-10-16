using Microsoft.Extensions.DependencyInjection;

namespace CzyDobrze.Application
{
    public static class Di
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}