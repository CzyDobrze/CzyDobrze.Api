using System;
using System.Collections.Generic;
using System.Linq;
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
            var allTextbooks = await _repository.ReadAll();

            return allTextbooks
                .Skip(request.Page * request.Amount)
                .Take(request.Amount)
                .AsEnumerable();
        }
    }
}