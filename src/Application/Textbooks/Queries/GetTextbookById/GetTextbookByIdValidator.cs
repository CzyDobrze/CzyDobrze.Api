using System;
using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
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
                .NotEmpty();
        }
    }
}