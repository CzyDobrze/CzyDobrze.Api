using FluentValidation;

namespace CzyDobrze.Application.Exercises.Queries.GetExerciseById
{
    public class GetExerciseByIdValidator : AbstractValidator<GetExerciseById>
    {
        public GetExerciseByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}