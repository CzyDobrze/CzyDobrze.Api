using CzyDobrze.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CzyDobrze.Infrastructure.Common
{
    public static class Di
    {
        public static IServiceCollection AddDateTimeService(this IServiceCollection services)
            => services.AddTransient<IDateTimeService,DateTimeService>();
    }
}