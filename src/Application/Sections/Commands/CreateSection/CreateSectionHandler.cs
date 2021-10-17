using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Section;
using MediatR;

namespace CzyDobrze.Application.Sections.Commands.CreateSection
{
    public class CreateSectionHandler : IRequestHandler<CreateSection, Section>
    {
        private readonly ITextbookRepository _repository;

        public CreateSectionHandler(ITextbookRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Section> Handle(CreateSection request, CancellationToken cancellationToken)
        {
            var textbook = await _repository.ReadById(request.TextbookId);

            var section = new Section(request.Title, request.Description);
            textbook.AddSection(section);

            return section;
        }
    }
}