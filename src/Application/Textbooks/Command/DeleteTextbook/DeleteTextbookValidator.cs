using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using FluentValidation;

namespace CzyDobrze.Application.Textbooks.Command.DeleteTextbook
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