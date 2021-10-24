using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Domain.Users.Contributor;

namespace CzyDobrze.Application.Common.Interfaces.Persistence.Users
{
    public interface IContributorRepository
    {
        // TODO implementation
        Task<Contributor> ReadById(Guid id);
        Task<IEnumerable<Contributor>> ReadAll();
        
        Task<Contributor> Create(Contributor entity);
        Task<Contributor> Update(Contributor entity);
        Task Delete(Contributor entity);
    }
}