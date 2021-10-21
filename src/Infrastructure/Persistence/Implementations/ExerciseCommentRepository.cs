using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Comment;

namespace CzyDobrze.Infrastructure.Persistence.Implementations
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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExerciseComment>> ReadAllFromGivenExerciseId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ExerciseComment> Create(Guid parentId, ExerciseComment entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ExerciseComment> Update(ExerciseComment entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(ExerciseComment entity)
        {
            throw new NotImplementedException();
        }
    }
}