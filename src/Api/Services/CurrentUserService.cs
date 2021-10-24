using System;
using System.Security.Claims;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces;
using CzyDobrze.Application.Common.Interfaces.Persistence.Users;
using CzyDobrze.Domain.Users.Contributor;
using CzyDobrze.Domain.Users.Moderator;
using CzyDobrze.Domain.Users.User;
using CzyDobrze.Infrastructure.Persistence.Identity;
using Microsoft.AspNetCore.Http;

namespace CzyDobrze.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IUserRepository _userRepository;
        private readonly IContributorRepository _contributorRepository;
        private readonly IModeratorRepository _moderatorRepository;
        private readonly IDbUserRepository _dbUserRepository;

        public CurrentUserService(IHttpContextAccessor accessor, IUserRepository userRepository, IContributorRepository contributorRepository, IModeratorRepository moderatorRepository, IDbUserRepository dbUserRepository)
        {
            _accessor = accessor;
            _userRepository = userRepository;
            _contributorRepository = contributorRepository;
            _moderatorRepository = moderatorRepository;
            _dbUserRepository = dbUserRepository;
        }

        public async Task<User> GetUser()
            => await _userRepository.ReadById(await GetUserId());
        
        public async Task<Contributor> GetContributor()
            => await _contributorRepository.ReadById(await GetUserId());

        public async Task<Moderator> GetModerator()
            => await _moderatorRepository.ReadById(await GetUserId());

        public async Task<bool> IsContributor()
            => await _contributorRepository.Any(await GetUserId());

        public async Task<bool> IsModerator()
            => await _moderatorRepository.Any(await GetUserId());

        public async Task<Guid> GetUserId()
        {
            var auth0Id = GetAuth0Id();
            
            var userId = await _dbUserRepository.FindByAuth0Id(auth0Id);
            if (userId != Guid.Empty) return userId;

            var user = new DbUser(auth0Id);
            var create = await _dbUserRepository.Create(user);

            return create.Id;
        }

        private string GetAuth0Id()
            => _accessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}