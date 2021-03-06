using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Vote;
using MediatR;

namespace CzyDobrze.Application.Votes.AnswerVotes.AnswerDownvote
{
    public class AnswerDownvoteHandler : IRequestHandler<AnswerDownvote>
    {
        private readonly IAnswerRepository _repository;
        private readonly ICurrentUserService _userService;

        public AnswerDownvoteHandler(IAnswerRepository repository, ICurrentUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }
        
        public async Task<Unit> Handle(AnswerDownvote request, CancellationToken cancellationToken)
        {
            var answer = await _repository.ReadById(request.AnswerId);
            if (answer == null) throw new EntityNotFoundException();

            if (await _userService.IsContributor() == false)
                throw new AuthorizationException();

            var contributor = await _userService.GetContributor();
            
            var userVotes = answer.Votes.Where(x => x.Voter.Id == contributor.Id);
            foreach (var userVote in userVotes) // for loop is probably useless (probably)
            {
                answer.DeleteVote(userVote);
            }

            answer.AddVote(AnswerVote.Downvote(contributor));

            await _repository.Update(answer);

            return Unit.Value;
        }
    }
}