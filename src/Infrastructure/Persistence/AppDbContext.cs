using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces;
using CzyDobrze.Core;
using CzyDobrze.Domain.Content.Answer;
using CzyDobrze.Domain.Content.Comment;
using CzyDobrze.Domain.Content.Exercise;
using CzyDobrze.Domain.Content.Section;
using CzyDobrze.Domain.Content.Textbook;
using Microsoft.EntityFrameworkCore;

namespace CzyDobrze.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        
        public AppDbContext(DbContextOptions options, IDateTimeService dateTime) : base(options)
        {
            _dateTime = dateTime;
        }
        
        public DbSet<Textbook> Textbooks { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<ExerciseComment> ExerciseComments { get; set; }
        public DbSet<AnswerComment> AnswerComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            UpdateLastUpdatedField();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateLastUpdatedField();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateLastUpdatedField()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Entity && e.State is EntityState.Modified);

            foreach (var entry in entries)
            {
                var entity = (Entity) entry.Entity;
                entity.Update(_dateTime.GetCurrentTime());
                Entry(entity).Property(x => x.Updated).IsModified = true;
            }
        }
    }
}