using FluentValidation;

namespace CzyDobrze.Application.Votes.ExerciseCommentVotes.ExerciseCommentResetVote
{
    public class ExerciseCommentResetVoteValidator : AbstractValidator<ExerciseCommentResetVote>
    {
        public ExerciseCommentResetVoteValidator()
        {
            RuleFor(x => x.ExerciseId)
                .NotEmpty();
        }
    }
}