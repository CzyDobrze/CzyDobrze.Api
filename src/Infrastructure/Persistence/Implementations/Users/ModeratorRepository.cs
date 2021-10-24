using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Users;
using CzyDobrze.Domain.Users.Moderator;
using Microsoft.EntityFrameworkCore;

namespace CzyDobrze.Infrastructure.Persistence.Implementations.Users
{
    public class ModeratorRepository : IModeratorRepository
    {
        private readonly AppDbContext _dbContext;

        public ModeratorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Moderator> ReadById(Guid id)
        {
            var dbUser = await _dbContext.Users.FindAsync(id);
            if (dbUser == null) return null;
            return new Moderator(dbUser.Id, dbUser.Created, dbUser.Updated);
        }

        public async Task<IEnumerable<Moderator>> ReadAll()
        {
            var dbUsers = await _dbContext.Users.ToListAsync();
            return dbUsers.Where(x => x.IsModerator).Select(dbUser => new Moderator(dbUser.Id, dbUser.Created, dbUser.Updated)).ToList();
        }

        public async Task<Moderator> Create(Moderator entity)
        {
            var dbUser = await _dbContext.Users.FindAsync(entity.Id);
            if (dbUser == null) return null;
            dbUser.IsContributor = true;
            _dbContext.Users.Update(dbUser);
            return new Moderator(dbUser.Id, dbUser.Created, dbUser.Updated);
        }

        public async Task<Moderator> Update(Moderator entity)
        {
            var dbUser = await _dbContext.Users.FindAsync(entity.Id);
            if (dbUser is not { IsModerator: true }) return null;
            _dbContext.Users.Update(dbUser);
            return new Moderator(dbUser.Id, dbUser.Created, dbUser.Updated);
        }

        public async Task Delete(Moderator entity)
        {
            var dbUser = await _dbContext.Users.FindAsync(entity.Id);
            if (dbUser == null) return;
            dbUser.IsModerator = false;
            _dbContext.Users.Update(dbUser);
            return;
        }
    }
}