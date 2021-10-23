using FluentValidation;

namespace CzyDobrze.Application.Votes.ExerciseCommentVotes.ExerciseCommentDownvote
{
    public class ExerciseCommentDownvoteValidator : AbstractValidator<ExerciseCommentDownvote>
    {
        public ExerciseCommentDownvoteValidator()
        {
            RuleFor(x => x.ExerciseId)
                .NotEmpty();
        }
    }
}