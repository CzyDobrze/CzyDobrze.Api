using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Domain.Users.User;

namespace CzyDobrze.Application.Common.Interfaces.Persistence.Users
{
    public interface IUserRepository
    {
        Task<User> ReadById(Guid id);
        Task<IEnumerable<User>> ReadAll();
        
        Task Create(User entity);
        Task Update(User entity);
        Task Delete(User entity);
    }
}