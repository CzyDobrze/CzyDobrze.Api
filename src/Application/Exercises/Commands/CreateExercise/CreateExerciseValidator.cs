using FluentValidation;

namespace CzyDobrze.Application.Exercises.Commands.CreateExercise
{
    public class CreateExerciseValidator : AbstractValidator<CreateExercise>
    {
        public CreateExerciseValidator()
        {
            RuleFor(x => x.SectionId)
                .NotEmpty();

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.InBookId)
                .NotEmpty();
        }
    }
}