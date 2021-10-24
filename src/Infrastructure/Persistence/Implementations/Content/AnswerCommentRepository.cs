using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Comment;
using Microsoft.EntityFrameworkCore;

namespace CzyDobrze.Infrastructure.Persistence.Implementations.Content
{
    public class AnswerCommentRepository : IAnswerCommentRepository
    {
        private readonly AppDbContext _dbContext;

        public AnswerCommentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AnswerComment> ReadById(Guid id)
        {
            return await _dbContext.AnswerComments
                .Include(x => x.Votes)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<AnswerComment>> ReadAllFromGivenAnswerId(Guid id)
        {
            return await _dbContext.Answers
                .Where(x => x.Id == id)
                .Select(x => x.AnswerComments)
                .FirstOrDefaultAsync();
        }

        public async Task<AnswerComment> Create(Guid parentId, AnswerComment entity)
        {
            var parent = await _dbContext.Answers.FindAsync(parentId);

            parent.AddComment(entity);
            
            var update = _dbContext.Answers.Update(parent);
            await _dbContext.SaveChangesAsync();
            
            return update.Entity.AnswerComments.First();
        }

        public async Task<AnswerComment> Update(AnswerComment entity)
        {
            var update = _dbContext.AnswerComments.Update(entity);
            await _dbContext.SaveChangesAsync();

            return update.Entity;
        }

        public async Task Delete(AnswerComment entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}