using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using MediatR;

namespace CzyDobrze.Application.Sections.Commands.DeleteSection
{
    public class DeleteSectionHandler : IRequestHandler<DeleteSection>
    {
        private readonly ISectionRepository _repository;

        public DeleteSectionHandler(ISectionRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Unit> Handle(DeleteSection request, CancellationToken cancellationToken)
        {
            var section = await _repository.ReadById(request.Id);
            if (section == null) throw new EntityNotFoundException();

            await _repository.Delete(section);
            
            return Unit.Value;
        }
    }
}