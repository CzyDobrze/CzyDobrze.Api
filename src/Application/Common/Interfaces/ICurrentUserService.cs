using System;
using System.Threading.Tasks;
using CzyDobrze.Domain.Users.Contributor;
using CzyDobrze.Domain.Users.Moderator;
using CzyDobrze.Domain.Users.User;

namespace CzyDobrze.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        Task<User> GetUser();
        Task<Contributor> GetContributor();
        Task<Moderator> GetModerator();
        Task<bool> IsContributor();
        Task<bool> IsModerator();
        Task<Guid> GetUserId();
    }
}