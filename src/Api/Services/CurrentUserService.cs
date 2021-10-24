using System;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces;
using CzyDobrze.Domain.Users.Contributor;
using CzyDobrze.Domain.Users.Moderator;
using CzyDobrze.Domain.Users.User;
using Microsoft.AspNetCore.Http;

namespace CzyDobrze.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<User> GetUser()
        {
            throw new NotImplementedException();
        }

        public async Task<Contributor> GetContributor()
        {
            throw new NotImplementedException();
        }

        public async Task<Moderator> GetModerator()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsContributor()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsModerator()
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> GetUserId()
        {
            throw new NotImplementedException();
        }
    }
}