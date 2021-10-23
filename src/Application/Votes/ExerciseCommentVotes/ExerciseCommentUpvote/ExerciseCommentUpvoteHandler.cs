using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Vote;
using MediatR;

namespace CzyDobrze.Application.Votes.ExerciseCommentVotes.ExerciseCommentUpvote
{
    public class ExerciseCommentUpvoteHandler : IRequestHandler<ExerciseCommentUpvote>
    {
        private readonly IExerciseCommentRepository _repository;
        private readonly ICurrentUserService _userService;

        public ExerciseCommentUpvoteHandler(IExerciseCommentRepository repository, ICurrentUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }
        
        public async Task<Unit> Handle(ExerciseCommentUpvote request, CancellationToken cancellationToken)
        {
            var exercise = await _repository.ReadById(request.ExerciseId);
            if (exercise == null) throw new EntityNotFoundException();

            if (await _userService.IsContributor() == false)
                throw new AuthorizationException();

            var contributor = await _userService.GetContributor();
            
            var userVotes = exercise.Votes.Where(x => x.Voter.Id == contributor.Id);
            foreach (var userVote in userVotes)
            {
                exercise.DeleteVote(userVote);
            }

            exercise.AddVote(ExerciseCommentVote.Upvote(contributor));

            await _repository.Update(exercise);

            return Unit.Value;
        }
    }
}