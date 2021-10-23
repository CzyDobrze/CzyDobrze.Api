using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Vote;
using MediatR;

namespace CzyDobrze.Application.Votes.ExerciseCommentVotes.ExerciseCommentDownvote
{
    public class ExerciseCommentDownvoteHandler : IRequestHandler<ExerciseCommentDownvote>
    {
        private readonly IExerciseCommentRepository _repository;
        private readonly ICurrentUserService _userService;

        public ExerciseCommentDownvoteHandler(IExerciseCommentRepository repository, ICurrentUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }
        
        public async Task<Unit> Handle(ExerciseCommentDownvote request, CancellationToken cancellationToken)
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

            exercise.AddVote(ExerciseCommentVote.Downvote(contributor));

            await _repository.Update(exercise);

            return Unit.Value;
        }
    }
}