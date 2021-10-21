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
            return await _dbContext.Exercises.FindAsync(id);
        }

        public async Task<IEnumerable<Exercise>> ReadAllFromGivenSectionId(Guid id)
        {
            // TODO not optimal
            return await _dbContext.Sections.Where(x => x.Id == id).Select(x => x.Exercises).FirstOrDefaultAsync();
        }

        public async Task<Exercise> Create(Guid parentId, Exercise entity)
        {
            var section = await _dbContext.Sections.FindAsync(parentId);
            section.AddExercise(entity);
            var update = _dbContext.Sections.Update(section);
            await _dbContext.SaveChangesAsync();
            
            // TODO return created entity
            throw new NotImplementedException();
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