using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Infrastructure.Persistence.Identity;

namespace CzyDobrze.Infrastructure.Persistence.Implementations
{
    public interface IDbUserRepository
    {
        Task<DbUser> ReadById(Guid id);
        Task<IEnumerable<DbUser>> ReadAll();
        
        Task<DbUser> Create(DbUser entity);
        Task<DbUser> Update(DbUser entity);
        Task Delete(DbUser entity);
    }
}