using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Users;
using CzyDobrze.Domain.Users.Contributor;
using Microsoft.EntityFrameworkCore;

namespace CzyDobrze.Infrastructure.Persistence.Implementations.Users
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
            return dbUser is not {IsContributor: true} ? null : 
                new Contributor(dbUser.Id, dbUser.Created, dbUser.Updated, dbUser.DisplayName, dbUser.Points);
        }

        public async Task<IEnumerable<Contributor>> ReadAll()
        {
            return await _dbContext.Users
                .Where(x => x.IsContributor)
                .Select(dbuser => new Contributor(dbuser.Id, dbuser.Created, dbuser.Updated, dbuser.DisplayName, dbuser.Points))
                .ToArrayAsync();
        }

        public async Task<Contributor> Create(Contributor entity)
        {
            var dbUser = await _dbContext.Users.FindAsync(entity.Id);
            
            if (dbUser == null) return null;
            dbUser.DisplayName = entity.DisplayName;
            dbUser.Points = entity.Points;
            dbUser.IsContributor = true;

            _dbContext.Users.Update(dbUser);
            await _dbContext.SaveChangesAsync();
            
            return new Contributor(dbUser.Id, dbUser.Created, dbUser.Updated, dbUser.DisplayName, dbUser.Points);
        }

        public async Task<Contributor> Update(Contributor entity)
        {
            var dbUser = await _dbContext.Users.FindAsync(entity.Id);

            if (dbUser is not { IsContributor: true }) return null;
            dbUser.DisplayName = entity.DisplayName;
            dbUser.Points = entity.Points;
            
            _dbContext.Users.Update(dbUser);
            await _dbContext.SaveChangesAsync();
            
            return new Contributor(dbUser.Id, dbUser.Created, dbUser.Updated, dbUser.DisplayName, dbUser.Points);
        }

        public async Task Delete(Contributor entity)
        {
            var dbUser = await _dbContext.Users.FindAsync(entity.Id);
            
            if (dbUser == null) return;
            dbUser.IsContributor = false;
            
            _dbContext.Users.Update(dbUser);
            await _dbContext.SaveChangesAsync();
        }
    }
}