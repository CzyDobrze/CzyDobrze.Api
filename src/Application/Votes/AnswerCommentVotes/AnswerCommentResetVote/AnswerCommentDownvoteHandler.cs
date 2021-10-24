using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Vote;
using MediatR;

namespace CzyDobrze.Application.Votes.AnswerCommentVotes.AnswerCommentResetVote
{
    public class AnswerCommentResetVoteHandler : IRequestHandler<AnswerCommentResetVote>
    {
        private readonly ICurrentUserService _currentUser;
        private readonly IAnswerCommentRepository _repository;

        public AnswerCommentResetVoteHandler(ICurrentUserService currentUser, IAnswerCommentRepository repository)
        {
            _currentUser = currentUser;
            _repository = repository;
        }
        
        public async Task<Unit> Handle(AnswerCommentResetVote request, CancellationToken cancellationToken)
        {
            var answerComment = await _repository.ReadById(request.AnswerCommentId);
            if (answerComment == null) throw new EntityNotFoundException();

            if (!await _currentUser.IsContributor())
                throw new AuthorizationException();
            var contributor = await _currentUser.GetContributor();
            
            var userVotes = answerComment.Votes.Where(x => x.Voter.Id == contributor.Id);
            foreach (var userVote in userVotes)
            {
                answerComment.DeleteVote(userVote);
            }

            await _repository.Update(answerComment);

            return Unit.Value;
        }
    }
}