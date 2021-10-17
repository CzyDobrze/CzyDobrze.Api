using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Textbook;
using MediatR;

namespace CzyDobrze.Application.Textbooks.Queries.GetAllTextbooks
{
    public class GetAllTextbooksHandler : IRequestHandler<GetAllTextbooks, IEnumerable<Textbook>>
    {
        private readonly ITextbookRepository _repository;

        public GetAllTextbooksHandler(ITextbookRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Textbook>> Handle(GetAllTextbooks request, CancellationToken cancellationToken)
        {
            return await _repository.ReadAll();
        }
    }
}