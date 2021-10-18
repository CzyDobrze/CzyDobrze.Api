using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using MediatR;
using CzyDobrze.Domain.Content.Section;

namespace CzyDobrze.Application.Sections.Queries.GetSectionById
{
    public class GetSectionByIdHandler : IRequestHandler<GetSectionById, Section>
    {
        private readonly ISectionRepository _repository;

        public GetSectionByIdHandler(ISectionRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Section> Handle(GetSectionById request, CancellationToken cancellationToken)
        {
            var section = await _repository.ReadById(request.Id);

            if (section == null) throw new EntityNotFoundException();

            return section;
        }
    }
}