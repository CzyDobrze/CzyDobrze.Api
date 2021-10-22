using FluentValidation;

namespace CzyDobrze.Application.Comments.ToExercises.Commands.DeleteExerciseComment
{
    public class DeleteExerciseCommentValidator : AbstractValidator<DeleteExerciseComment>
    {
        public DeleteExerciseCommentValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}