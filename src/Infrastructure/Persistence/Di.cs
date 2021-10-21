﻿using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Infrastructure.Persistence.Implementations;
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
                options.UseSqlite("Data Source=czydobrze.db", x =>
                {
                    x.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name);
                });
            });

            services.AddTransient<ITextbookRepository, TextbookRepository>();
            services.AddTransient<ISectionRepository, SectionRepository>();
            services.AddTransient<IExerciseRepository, ExerciseRepository>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            
            return services;
        }
    }
}