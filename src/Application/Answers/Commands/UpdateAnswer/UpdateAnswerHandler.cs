using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Answer;
using MediatR;

namespace CzyDobrze.Application.Answers.Commands.UpdateAnswer
{
    public class UpdateAnswerHandler : IRequestHandler<UpdateAnswer, Answer>
    {
        private readonly IAnswerRepository _repository;
        private readonly ICurrentUserService _userService;
        
        public UpdateAnswerHandler(IAnswerRepository repository, ICurrentUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }
        
        public async Task<Answer> Handle(UpdateAnswer request, CancellationToken cancellationToken)
        {
            var answer = await _repository.ReadById(request.Id);
            if (answer == null) throw new EntityNotFoundException();

            if (await _userService.IsModerator())
            {
                if(request.Accepted)
                    answer.Accept();
                else
                    answer.Reject();
            }
            else if (await _userService.IsContributor())
            {
                var contributor = await _userService.GetContributor();
                if (answer.Author.Id != contributor.Id)
                    throw new AuthorizationException();
                
                answer.SetContent(request.Content);
                if(request.Accepted)
                    answer.Accept();
                else
                    answer.Reject();
            }
            else throw new AuthorizationException();

            await _repository.Update(answer);

            return answer;
        }
    }
}