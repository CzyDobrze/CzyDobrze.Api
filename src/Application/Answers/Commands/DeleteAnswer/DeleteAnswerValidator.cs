using FluentValidation;

namespace CzyDobrze.Application.Answers.Commands.DeleteAnswer
{
    public class DeleteAnswerValidator : AbstractValidator<DeleteAnswer>
    {
        public DeleteAnswerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}