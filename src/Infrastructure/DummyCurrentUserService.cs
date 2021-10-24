using System;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces;
using CzyDobrze.Domain.Users.Contributor;
using CzyDobrze.Domain.Users.Moderator;
using CzyDobrze.Domain.Users.User;

namespace CzyDobrze.Infrastructure
{
    public class DummyCurrentUserService : ICurrentUserService
    {
        
        // This crappy delays are here just to hide warnings :)
        public async Task<User> GetUser()
        {
            await Task.Delay(1);
            return new User("Test");
        }

        public async Task<Contributor> GetContributor()
        {
            await Task.Delay(1);
            return new Contributor();
        }

        public async Task<Moderator> GetModerator()
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }

        public async Task<bool> IsContributor()
        {
            await Task.Delay(1);
            return true;
        }

        public async Task<bool> IsModerator()
        {
            await Task.Delay(1);
            return true;
        }

        public async Task<Guid> GetUserId()
        {
            await Task.Delay(1);
            return new Guid();
        }
    }
}