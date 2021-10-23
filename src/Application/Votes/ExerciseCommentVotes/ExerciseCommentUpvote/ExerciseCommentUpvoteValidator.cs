using FluentValidation;

namespace CzyDobrze.Application.Votes.ExerciseCommentVotes.ExerciseCommentUpvote
{
    public class ExerciseCommentUpvoteValidator : AbstractValidator<ExerciseCommentUpvote>
    {
        public ExerciseCommentUpvoteValidator()
        {
            RuleFor(x => x.ExerciseId)
                .NotEmpty();
        }
    }
}