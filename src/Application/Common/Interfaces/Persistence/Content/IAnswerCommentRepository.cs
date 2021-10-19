using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Domain.Content.Answer;
using CzyDobrze.Domain.Content.Comment;

namespace CzyDobrze.Application.Common.Interfaces.Persistence.Content
{
    public interface IAnswerCommentRepository
    {
        Task<AnswerComment> ReadById(Guid id);
        Task<IEnumerable<AnswerComment>> ReadAllFromGivenExerciseId(Guid id);
        
        Task<AnswerComment> Create(Guid parentId, AnswerComment entity);
        Task<AnswerComment> Update(AnswerComment entity);
        Task Delete(AnswerComment entity);
    }
}