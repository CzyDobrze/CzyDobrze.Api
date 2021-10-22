using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Exercise;
using Microsoft.EntityFrameworkCore;

namespace CzyDobrze.Infrastructure.Persistence.Implementations
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly AppDbContext _dbContext;

        public ExerciseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Exercise> ReadById(Guid id)
        {
            return await _dbContext.Exercises
                .Include(x => x.Answers)
                .Include(x => x.Comments)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Exercise>> ReadAllFromGivenSectionId(Guid id)
        {
            return await _dbContext.Sections
                .Where(x => x.Id == id)
                .Select(x => x.Exercises)
                .SingleOrDefaultAsync();
        }

        public async Task<Exercise> Create(Guid parentId, Exercise entity)
        {
            var section = await _dbContext.Sections.FindAsync(parentId);
            
            section.AddExercise(entity);
            
            var update = _dbContext.Sections.Update(section);
            await _dbContext.SaveChangesAsync();

            return update.Entity.Exercises.First();
        }

        public async Task<Exercise> Update(Exercise entity)
        {
            var update = _dbContext.Exercises.Update(entity);
            await _dbContext.SaveChangesAsync();

            return update.Entity;
        }

        public async Task Delete(Exercise entity)
        {
            _dbContext.Exercises.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}