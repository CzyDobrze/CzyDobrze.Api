﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Domain.Users.User;

namespace CzyDobrze.Application.Common.Interfaces.Persistence.Users
{
    public interface IUserRepository
    {
        Task<User> ReadById(Guid id);
        Task<IEnumerable<User>> ReadAll();
        
        Task<User> Create(User entity);
        Task<User> Update(User entity);
        Task Delete(User entity);
    }
}