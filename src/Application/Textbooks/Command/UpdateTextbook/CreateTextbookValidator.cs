using System;
using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using FluentValidation;
namespace CzyDobrze.Application.Textbooks.Command.UpdateTextbook
{
    public class CreateTextbookValidator : AbstractValidator<UpdateTextbook>
    {
        private readonly ITextbookRepository _repository;
        
        public CreateTextbookValidator(ITextbookRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .MustAsync(TextbookExists).WithMessage("Textbook with given ID does not exist");

            RuleFor(x => x.Title)
                .NotEmpty();

            RuleFor(x => x.Subject)
                .NotEmpty();

            RuleFor(x => x.Publisher)
                .NotEmpty();

            RuleFor(x => x.ClassYear)
                .InclusiveBetween(1, 12);
        }

        private async Task<bool> TextbookExists(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.ReadById(id) != null;
        }
    }
}