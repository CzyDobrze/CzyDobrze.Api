using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CzyDobrze.Infrastructure.Persistence.Identity
{
    public interface IDbUserRepository
    {
        Task<DbUser> ReadById(Guid id);
        Task<IEnumerable<DbUser>> ReadAll();

        Task<Guid> FindByAuth0Id(string auth0Id);
        
        Task<DbUser> Create(DbUser entity);
        Task<DbUser> Update(DbUser entity);
        Task Delete(DbUser entity);
    }
}