using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Textbook;
using MediatR;

namespace CzyDobrze.Application.Textbooks.Queries.GetTextbookById
{
    public class GetTextbookByIdHandler : IRequestHandler<GetTextbookById, Textbook>
    {
        private readonly ITextbookRepository _repository;

        public GetTextbookByIdHandler(ITextbookRepository repository)
        {
            _repository = repository;
        }

        public async Task<Textbook> Handle(GetTextbookById request, CancellationToken cancellationToken)
        {
            var textbook = await _repository.ReadById(request.Id);
            
            if (textbook is null) throw new EntityNotFoundException();
            return textbook;
        }
    }
}