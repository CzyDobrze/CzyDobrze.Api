using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Comment;
using Microsoft.EntityFrameworkCore;

namespace CzyDobrze.Infrastructure.Persistence.Implementations.Content
{
    public class ExerciseCommentRepository : IExerciseCommentRepository
    {
        private readonly AppDbContext _dbContext;

        public ExerciseCommentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ExerciseComment> ReadById(Guid id)
        {
            return await _dbContext.ExerciseComments
                .Include(x => x.Votes)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ExerciseComment>> ReadAllFromGivenExerciseId(Guid id)
        {
            return await _dbContext.Exercises
                .Where(x => x.Id == id)
                .Select(x => x.Comments)
                .SingleOrDefaultAsync();
        }

        public async Task<ExerciseComment> Create(Guid parentId, ExerciseComment entity)
        {
            var parent = await _dbContext.Exercises.FindAsync(parentId);
            
            parent.AddComment(entity);
            
            var update = _dbContext.Exercises.Update(parent);
            await _dbContext.SaveChangesAsync();

            return update.Entity.Comments.First();
        }

        public async Task<ExerciseComment> Update(ExerciseComment entity)
        {
            var update = _dbContext.ExerciseComments.Update(entity);
            await _dbContext.SaveChangesAsync();

            return update.Entity;
        }

        public async Task Delete(ExerciseComment entity)
        {
            _dbContext.ExerciseComments.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}