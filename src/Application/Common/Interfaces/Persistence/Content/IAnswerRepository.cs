using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Domain.Content.Answer;

namespace CzyDobrze.Application.Common.Interfaces.Persistence.Content
{
    public interface IAnswerRepository
    {
        Task<Answer> ReadById(Guid id);
        Task<IEnumerable<Answer>> ReadAll();
        
        Task<Answer> Create(Answer entity);
        Task<Answer> Update(Answer entity);
        Task Delete(Answer entity);
    }
}