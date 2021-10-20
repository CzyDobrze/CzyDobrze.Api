using FluentValidation;

namespace CzyDobrze.Application.Textbooks.Commands.CreateTextbook
{
    public class CreateTextbookValidator : AbstractValidator<CreateTextbook>
    {
        public CreateTextbookValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty();

            RuleFor(x => x.Subject)
                .NotEmpty();

            RuleFor(x => x.Publisher)
                .NotEmpty();

            RuleFor(x => x.ClassYear)
                .InclusiveBetween(1, 12);
        }
    }
}