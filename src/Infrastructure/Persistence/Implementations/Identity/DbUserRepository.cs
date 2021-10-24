using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Infrastructure.Persistence.Identity;
using Microsoft.EntityFrameworkCore;

namespace CzyDobrze.Infrastructure.Persistence.Implementations.Identity
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
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<IEnumerable<DbUser>> ReadAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<DbUser> Create(DbUser entity)
        {
            var dbUser = await _dbContext.Users.AddAsync(entity);
            return dbUser.Entity;
        }

        public async Task<DbUser> Update(DbUser entity)
        {
            var dbUser = _dbContext.Users.Update(entity);
            if (dbUser == null) return null;
            return await Task.FromResult(dbUser.Entity);
        }

        public Task Delete(DbUser entity)
        {
            _dbContext.Users.Remove(entity);
            return Task.CompletedTask;
        }
    }
}