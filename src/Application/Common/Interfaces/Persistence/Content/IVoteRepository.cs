using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Domain.Content.Vote;

namespace CzyDobrze.Application.Common.Interfaces.Persistence.Content
{
    public interface IVoteRepository
    {
        Task<Vote> ReadById(Guid id);
        Task<IEnumerable<Vote>> ReadAll();
        
        Task<Vote> Create(Vote entity);
        Task<Vote> Update(Vote entity);
        Task Delete(Vote entity);
    }
}