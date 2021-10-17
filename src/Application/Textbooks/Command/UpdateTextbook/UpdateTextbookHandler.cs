using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Textbook;
using MediatR;

namespace CzyDobrze.Application.Textbooks.Command.UpdateTextbook
{
    public class UpdateTextbookHandler : IRequestHandler<UpdateTextbook, Textbook>
    {
        private readonly ITextbookRepository _repository;

        public UpdateTextbookHandler(ITextbookRepository repository)
        {
            _repository = repository;
        }

        public async Task<Textbook> Handle(UpdateTextbook request, CancellationToken cancellationToken)
        {
            var textbook = await _repository.ReadById(request.Id);
            if (textbook is null) throw new EntityNotFoundException();
            
            textbook.SetTitle(request.Title);
            textbook.SetPublisher(request.Publisher);
            textbook.SetSubject(request.Subject);
            textbook.SetClassYear(request.ClassYear);
            
            return await _repository.Update(textbook);
        }
    }
}