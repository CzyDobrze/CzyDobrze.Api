using System;
using System.Threading;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using FluentValidation;
using System.Threading.Tasks;

namespace CzyDobrze.Application.Sections.Commands.CreateSection
{
    public class CreateSectionValidator : AbstractValidator<CreateSection>
    {
        private readonly ITextbookRepository _repository;
        
        public CreateSectionValidator(ITextbookRepository repository)
        {
            _repository = repository;
            
            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.Title)
                .NotEmpty();

            RuleFor(x => x.TextbookId)
                .NotEmpty()
                .MustAsync(TextbookExists).WithMessage("Textbook with given ID does not exist");
        }

        private async Task<bool> TextbookExists(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.ReadById(id) != null;
        }
    }
}