using FluentValidation;

namespace CzyDobrze.Application.Textbooks.Commands.DeleteTextbook
{
    public class DeleteTextbookValidator : AbstractValidator<DeleteTextbook>
    {
        public DeleteTextbookValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}