using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Answer;
using CzyDobrze.Domain.Users.Contributor;
using MediatR;

namespace CzyDobrze.Application.Answers.Commands.CreateAnswer
{
    public class CreateAnswerHandler : IRequestHandler<CreateAnswer, Answer>
    {
        private readonly IAnswerRepository _repository;
        private readonly ICurrentUserService _userService;

        public CreateAnswerHandler(IAnswerRepository repository, ICurrentUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }
        
        public async Task<Answer> Handle(CreateAnswer request, CancellationToken cancellationToken)
        {
            Contributor contributor;
            if (await _userService.IsContributor())
                contributor = await _userService.GetContributor();
            else
                throw new AuthorizationException();

            return await _repository.Create(request.ExerciseId, new Answer(contributor, request.Content));
        }
    }
}