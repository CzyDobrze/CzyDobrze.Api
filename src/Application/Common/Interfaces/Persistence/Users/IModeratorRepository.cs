using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Domain.Users.Moderator;

namespace CzyDobrze.Application.Common.Interfaces.Persistence.Users
{
    public interface IModeratorRepository
    {
        Task<Moderator> ReadById(Guid id);
        Task<IEnumerable<Moderator>> ReadAll();
        
        Task Create(Moderator entity);
        Task Update(Moderator entity);
        Task Delete(Moderator entity);
    }
}