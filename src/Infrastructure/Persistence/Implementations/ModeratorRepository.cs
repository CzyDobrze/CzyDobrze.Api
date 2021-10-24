using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Users;
using CzyDobrze.Domain.Users.Moderator;

namespace CzyDobrze.Infrastructure.Persistence.Implementations
{
    public class ModeratorRepository : IModeratorRepository
    {
        private readonly AppDbContext _dbContext;

        public ModeratorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Moderator> ReadById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Moderator>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<Moderator> Create(Moderator entity)
        {
            throw new NotImplementedException();
        }

        public Task<Moderator> Update(Moderator entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Moderator entity)
        {
            throw new NotImplementedException();
        }
    }
}