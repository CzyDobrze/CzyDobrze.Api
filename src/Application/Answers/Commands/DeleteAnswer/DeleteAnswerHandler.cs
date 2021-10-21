using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using MediatR;

namespace CzyDobrze.Application.Answers.Commands.DeleteAnswer
{
    public class DeleteAnswerHandler : IRequestHandler<DeleteAnswer>
    {
        private readonly IAnswerRepository _repository;
        private readonly ICurrentUserService _currentUser;

        public DeleteAnswerHandler(IAnswerRepository repository, ICurrentUserService currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }
        
        public async Task<Unit> Handle(DeleteAnswer request, CancellationToken cancellationToken)
        {
            var answer = await _repository.ReadById(request.Id);

            if (!await _currentUser.IsModerator())
            {
                if (await _currentUser.IsContributor())
                {
                    var contributor = await _currentUser.GetContributor();
                    if (contributor.Id != answer.Id)
                        throw new AuthorizationException();
                } else throw new AuthorizationException();
            }

            await _repository.Delete(answer);
            
            return Unit.Value;
        }
    }
}