using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Section;
using MediatR;

namespace CzyDobrze.Application.Sections.Queries.GetAllSectionsOfTextbook
{
    public class GetAllSectionHandler : IRequestHandler<GetAllSectionsOfTextbook, IEnumerable<Section>>
    {
        private readonly ISectionRepository _repository;

        public GetAllSectionHandler(ISectionRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<Section>> Handle(GetAllSectionsOfTextbook request, CancellationToken cancellationToken)
        {
            var allSections = await _repository.ReadAllFromGivenTextbookId(request.TextbookId);

            return allSections
                .Skip(request.Page * request.Amount)
                .Take(request.Amount)
                .AsEnumerable();
        }
    }
}