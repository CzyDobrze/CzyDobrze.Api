using FluentValidation;

namespace CzyDobrze.Application.Exercises.Commands.DeleteExercise
{
    public class DeleteExerciseValidator : AbstractValidator<DeleteExercise>
    {
        public DeleteExerciseValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}