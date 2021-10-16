using System;
using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using FluentValidation;

namespace CzyDobrze.Application.Textbooks.Queries.GetTextbookById
{
    public class GetTextbookByIdValidator : AbstractValidator<GetTextbookById>
    {
        private readonly ITextbookRepository _repository;
        public GetTextbookByIdValidator(ITextbookRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .MustAsync(Exist);
        }

        private async Task<bool> Exist(Guid id, CancellationToken cancellationToken)
            => await _repository.ReadById(id) is not null;
    }
}