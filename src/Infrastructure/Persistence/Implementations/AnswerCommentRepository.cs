using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Comment;

namespace CzyDobrze.Infrastructure.Persistence.Implementations
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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AnswerComment>> ReadAllFromGivenAnswerId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<AnswerComment> Create(Guid parentId, AnswerComment entity)
        {
            throw new NotImplementedException();
        }

        public async Task<AnswerComment> Update(AnswerComment entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(AnswerComment entity)
        {
            throw new NotImplementedException();
        }
    }
}