using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Users;
using CzyDobrze.Domain.Users.User;
using Microsoft.EntityFrameworkCore;

namespace CzyDobrze.Infrastructure.Persistence.Implementations.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<User> ReadById(Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            return user == null ? null : new User(user.Id, user.Created, user.Updated, user.DisplayName);
        }

        public async Task<IEnumerable<User>> ReadAll()
        {
            return await _dbContext.Users
                .Select(dbuser => new User(dbuser.Id, dbuser.Created, dbuser.Updated, dbuser.DisplayName))
                .ToArrayAsync();
        }

        public async Task<User> Update(User entity)
        {
            var dbUser = await _dbContext.Users.FindAsync(entity.Id);

            if (dbUser is null) return null;
            dbUser.DisplayName = entity.DisplayName;
            
            _dbContext.Users.Update(dbUser);
            await _dbContext.SaveChangesAsync();
            
            return new User(dbUser.Id, dbUser.Created, dbUser.Updated, dbUser.DisplayName);
        }

        public async Task Delete(User entity)
        {
            var dbUser = await _dbContext.Users.FindAsync(entity.Id);
            
            _dbContext.Users.Remove(dbUser);
            await _dbContext.SaveChangesAsync();
        }
    }
}