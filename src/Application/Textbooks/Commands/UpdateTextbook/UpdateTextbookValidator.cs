using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using FluentValidation;

namespace CzyDobrze.Application.Textbooks.Commands.UpdateTextbook
{
    public class UpdateTextbookValidator : AbstractValidator<UpdateTextbook>
    {
        private readonly ITextbookRepository _repository;
        
        public UpdateTextbookValidator(ITextbookRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.Id)
                .NotEmpty();

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