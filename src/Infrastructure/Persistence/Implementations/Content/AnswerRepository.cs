using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Answer;
using Microsoft.EntityFrameworkCore;

namespace CzyDobrze.Infrastructure.Persistence.Implementations.Content
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly AppDbContext _dbContext;

        public AnswerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Answer> ReadById(Guid id)
        {
            return await _dbContext.Answers
                .Include(x => x.AnswerComments)
                .Include(x => x.Votes)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Answer>> ReadAllFromGivenExerciseId(Guid id)
        {
            return await _dbContext.Exercises
                .Where(x => x.Id == id)
                .Select(x => x.Answers)
                .FirstOrDefaultAsync();
        }

        public async Task<Answer> Create(Guid parentId, Answer entity)
        {
            var parent = await _dbContext.Exercises.FindAsync(parentId);
            
            parent.AddAnswer(entity);
            
            var update = _dbContext.Exercises.Update(parent);
            await _dbContext.SaveChangesAsync();

            return update.Entity.Answers.First();
        }

        public async Task<Answer> Update(Answer entity)
        {
            var update = _dbContext.Answers.Update(entity);
            await _dbContext.SaveChangesAsync();

            return update.Entity;
        }

        public async Task Delete(Answer entity)
        {
            _dbContext.Answers.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}