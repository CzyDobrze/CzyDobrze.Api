using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Application.Common.Interfaces.Persistence.Users;
using CzyDobrze.Infrastructure.Persistence.Identity;
using CzyDobrze.Infrastructure.Persistence.Implementations.Content;
using CzyDobrze.Infrastructure.Persistence.Implementations.Identity;
using CzyDobrze.Infrastructure.Persistence.Implementations.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CzyDobrze.Infrastructure.Persistence
{
    public static class Di
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite("Data Source=db/czydobrze.db", x =>
                {
                    x.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name);
                });
            });

            services.AddTransient<ITextbookRepository, TextbookRepository>();
            services.AddTransient<ISectionRepository, SectionRepository>();
            services.AddTransient<IExerciseRepository, ExerciseRepository>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<IExerciseCommentRepository, ExerciseCommentRepository>();
            services.AddTransient<IAnswerCommentRepository, AnswerCommentRepository>();
            
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IContributorRepository, ContributorRepository>();
            services.AddTransient<IModeratorRepository, ModeratorRepository>();
            
            services.AddTransient<IDbUserRepository, DbUserRepository>();
            
            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app
                .ApplicationServices.CreateScope().ServiceProvider
                .GetService<AppDbContext>()?.Database.Migrate();

            return app;
        }
    }
}