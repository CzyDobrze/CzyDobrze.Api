using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Textbook;
using MediatR;

namespace CzyDobrze.Application.Textbooks.Commands.CreateTextbook
{
    public class CreateTextbookHandler : IRequestHandler<CreateTextbook, Textbook>
    {
        private readonly ITextbookRepository _repository;

        public CreateTextbookHandler(ITextbookRepository repository)
        {
            _repository = repository;
        }

        public async Task<Textbook> Handle(CreateTextbook request, CancellationToken cancellationToken)
        {
            return await _repository.Create(new Textbook(request.Title, request.Subject, request.Publisher, request.ClassYear));
        }
    }
}