using FluentValidation;

namespace CzyDobrze.Application.Comments.ToExercises.Queries.GetExerciseCommentById
{
    public class GetExerciseCommentByIdValidator : AbstractValidator<GetExerciseCommentById>
    {
        public GetExerciseCommentByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}