using System;
using System.Threading;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using System.Threading.Tasks;
using FluentValidation;

namespace CzyDobrze.Application.Textbooks.Command.DeleteTextbook
{
    public class DeleteTextbookValidator : AbstractValidator<DeleteTextbook>
    {
        private readonly ITextbookRepository _repository;

        public DeleteTextbookValidator(ITextbookRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .MustAsync(TextbookExists).WithMessage("Textbook with given ID does not exist");

        }

        private async Task<bool> TextbookExists(Guid id, CancellationToken token)
        {
            return await _repository.ReadById(id) != null;
        }
    }
}