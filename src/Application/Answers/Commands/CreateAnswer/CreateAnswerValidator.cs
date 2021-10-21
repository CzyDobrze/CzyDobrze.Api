using FluentValidation;

namespace CzyDobrze.Application.Answers.Commands.CreateAnswer
{
    public class CreateAnswerValidator : AbstractValidator<CreateAnswer>
    {
        public CreateAnswerValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty();

            RuleFor(x => x.ExerciseId)
                .NotEmpty();
        }
    }
}