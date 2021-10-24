using FluentValidation;

namespace CzyDobrze.Application.Exercises.Commands.UpdateExercise
{
    public class UpdateExerciseValidator : AbstractValidator<UpdateExercise>
    {
        public UpdateExerciseValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.InBookId)
                .NotEmpty();
        }
    }
}