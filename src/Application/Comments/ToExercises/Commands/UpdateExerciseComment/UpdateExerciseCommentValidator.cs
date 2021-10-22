using FluentValidation;

namespace CzyDobrze.Application.Comments.ToExercises.Commands.UpdateExerciseComment
{
    public class UpdateExerciseCommentValidator : AbstractValidator<UpdateExerciseComment>
    {
        public UpdateExerciseCommentValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Content)
                .NotEmpty();
        }
    }
}