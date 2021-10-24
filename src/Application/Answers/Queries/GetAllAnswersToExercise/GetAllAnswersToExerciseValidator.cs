using FluentValidation;

namespace CzyDobrze.Application.Answers.Queries.GetAllAnswersToExercise
{
    public class GetAllAnswersToExerciseValidator : AbstractValidator<GetAllAnswersToExercise>
    {
        public GetAllAnswersToExerciseValidator()
        {
            RuleFor(x => x.ExerciseId)
                .NotEmpty();

            RuleFor(x => x.Amount)
                .InclusiveBetween(0, 100);
        }
    }
}