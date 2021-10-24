using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Users;
using CzyDobrze.Domain.Users.Contributor;
using CzyDobrze.Domain.Users.User;
using Microsoft.EntityFrameworkCore;

namespace CzyDobrze.Infrastructure.Persistence.Implementations
{
    public class ContributorRepository : IContributorRepository
    {
        private readonly AppDbContext _dbContext;

        public ContributorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Contributor> ReadById(Guid id)
        {
            var dbUser = await _dbContext.Users.FindAsync(id);
            if (dbUser == null) return null;
            return new Contributor(dbUser.Id, dbUser.Created, dbUser.Updated, dbUser.DisplayName, dbUser.Points);
        }

        public async Task<IEnumerable<Contributor>> ReadAll()
        {
            var dbUsers = await _dbContext.Users.ToListAsync();
            return dbUsers.Where(x => x.IsContributor).Select(dbUser => new Contributor(dbUser.Id, dbUser.Created, dbUser.Updated, dbUser.DisplayName, dbUser.Points)).ToList();
        }

        public async Task<Contributor> Create(Contributor entity)
        {
            var dbUser = await _dbContext.Users.FindAsync(entity.Id);
            if (dbUser == null) return null;
            dbUser.IsContributor = true;
            _dbContext.Users.Update(dbUser);
            return new Contributor(dbUser.Id, dbUser.Created, dbUser.Updated, dbUser.DisplayName, dbUser.Points);
        }

        public async Task<Contributor> Update(Contributor entity)
        {
            var dbUser = await _dbContext.Users.FindAsync(entity.Id);
            if (dbUser is not { IsContributor: true }) return null;
            dbUser.DisplayName = entity.DisplayName;
            dbUser.Points = entity.Points;
            _dbContext.Users.Update(dbUser);
            return new Contributor(dbUser.Id, dbUser.Created, dbUser.Updated, dbUser.DisplayName, dbUser.Points);
        }

        public async Task Delete(Contributor entity)
        {
            var dbUser = await _dbContext.Users.FindAsync(entity.Id);
            if (dbUser == null) return;
            _dbContext.Users.Remove(dbUser);
        }
    }
}