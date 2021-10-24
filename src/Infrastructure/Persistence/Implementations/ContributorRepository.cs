using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Users;
using CzyDobrze.Domain.Users.Contributor;

namespace CzyDobrze.Infrastructure.Persistence.Implementations
{
    public class ContributorRepository : IContributorRepository
    {
        private readonly AppDbContext _dbContext;

        public ContributorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Contributor> ReadById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contributor>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<Contributor> Create(Contributor entity)
        {
            throw new NotImplementedException();
        }

        public Task<Contributor> Update(Contributor entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Contributor entity)
        {
            throw new NotImplementedException();
        }
    }
}