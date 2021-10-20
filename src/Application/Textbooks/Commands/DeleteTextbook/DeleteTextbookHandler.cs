using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using MediatR;

namespace CzyDobrze.Application.Textbooks.Commands.DeleteTextbook
{
    public class DeleteTextbookHandler : IRequestHandler<DeleteTextbook>
    {
        private readonly ITextbookRepository _repository;

        public DeleteTextbookHandler(ITextbookRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Unit> Handle(DeleteTextbook request, CancellationToken cancellationToken)
        {
            var textbook = await _repository.ReadById(request.Id);
            if (textbook is null) throw new EntityNotFoundException();
            
            await _repository.Delete(textbook);
            
            return Unit.Value;
        }
    }
}