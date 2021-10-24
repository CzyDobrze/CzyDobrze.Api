using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Section;
using MediatR;

namespace CzyDobrze.Application.Sections.Commands.CreateSection
{
    public class CreateSectionHandler : IRequestHandler<CreateSection, Section>
    {
        private readonly ISectionRepository _repository;

        public CreateSectionHandler(ISectionRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Section> Handle(CreateSection request, CancellationToken cancellationToken)
        {
            return await _repository.Create(request.TextbookId, new Section(request.Title, request.Description));
        }
    }
}