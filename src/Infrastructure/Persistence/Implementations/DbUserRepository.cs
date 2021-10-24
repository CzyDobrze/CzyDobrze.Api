using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Infrastructure.Persistence.Identity;

namespace CzyDobrze.Infrastructure.Persistence.Implementations
{
    public class DbUserRepository : IDbUserRepository
    {
        private readonly AppDbContext _dbContext;

        public DbUserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<DbUser> ReadById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DbUser>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public async Task<DbUser> Create(DbUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<DbUser> Update(DbUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(DbUser entity)
        {
            throw new NotImplementedException();
        }
    }
}