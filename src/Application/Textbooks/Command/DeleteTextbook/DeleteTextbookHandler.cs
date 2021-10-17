using System;
using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Textbook;
using MediatR;

namespace CzyDobrze.Application.Textbooks.Command.DeleteTextbook
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
            Textbook textbookToBeDeleted = await _repository.ReadById(request.Id);
            await _repository.Delete(textbookToBeDeleted);
            return Unit.Value;
        }
    }
}