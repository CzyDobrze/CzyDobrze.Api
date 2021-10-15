using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Domain.Users.Contributor;

namespace CzyDobrze.Application.Common.Interfaces.Persistence.Users
{
    public interface IContributorRepository
    {
        Task<Contributor> ReadById(Guid id);
        Task<IEnumerable<Contributor>> ReadAll();
        
        Task Create(Contributor entity);
        Task Update(Contributor entity);
        Task Delete(Contributor entity);
    }
}