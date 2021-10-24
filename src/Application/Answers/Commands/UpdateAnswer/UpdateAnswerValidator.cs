using FluentValidation;

namespace CzyDobrze.Application.Answers.Commands.UpdateAnswer
{
    public class UpdateAnswerValidator : AbstractValidator<UpdateAnswer>
    {
        public UpdateAnswerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Content)
                .NotEmpty();
        }
    }
}