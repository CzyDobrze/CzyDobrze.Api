using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Section;
using MediatR;

namespace CzyDobrze.Application.Sections.Commands.UpdateSection
{
    public class UpdateSectionHandler : IRequestHandler<UpdateSection, Section>
    {
        private readonly ISectionRepository _repository;

        public UpdateSectionHandler(ISectionRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Section> Handle(UpdateSection request, CancellationToken cancellationToken)
        {
            var section = await _repository.ReadById(request.Id);

            if (section == null) throw new EntityNotFoundException();
            
            section.SetTitle(request.Title);
            section.SetDescription(request.Description);

            return section;
        }
    }
}