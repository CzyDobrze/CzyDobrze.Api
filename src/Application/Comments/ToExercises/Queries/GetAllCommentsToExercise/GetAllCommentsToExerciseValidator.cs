using FluentValidation;

namespace CzyDobrze.Application.Comments.ToExercises.Queries.GetAllCommentsToExercise
{
    public class GetAllCommentsToExerciseValidator : AbstractValidator<GetAllCommentsToExercise>
    {
        public GetAllCommentsToExerciseValidator()
        {
            RuleFor(x => x.ExerciseId)
                .NotEmpty();

            RuleFor(x => x.Amount)
                .InclusiveBetween(0, 100);
        }
    }
}