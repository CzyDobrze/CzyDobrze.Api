using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Domain.Content.Answer;
using CzyDobrze.Domain.Content.Exercise;

namespace CzyDobrze.Application.Common.Interfaces.Persistence.Content
{
    public interface IAnswerRepository
    {
        Task<Answer> ReadById(Guid id);
        Task<IEnumerable<Answer>> ReadAllFromGivenExerciseId(Guid id);
        
        Task<Answer> Create(Guid parentId, Answer entity);
        Task<Answer> Update(Answer entity);
        Task Delete(Answer entity);
    }
}