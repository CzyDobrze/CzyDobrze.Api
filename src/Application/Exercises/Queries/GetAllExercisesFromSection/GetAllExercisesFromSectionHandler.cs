using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Exercise;
using MediatR;

namespace CzyDobrze.Application.Exercises.Queries.GetAllExercisesFromSection
{
    public class GetAllExercisesFromSectionHandler : IRequestHandler<GetAllExercisesFromSection, IEnumerable<Exercise>>
    {
        private readonly IExerciseRepository _repository;

        public GetAllExercisesFromSectionHandler(IExerciseRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<Exercise>> Handle(GetAllExercisesFromSection request, CancellationToken cancellationToken)
        {
            var exercises = await _repository.ReadAllFromGivenSectionId(request.SectionId);

            return exercises
                .Skip(request.Page * request.Amount)
                .Take(request.Amount)
                .AsEnumerable();
        }
    }
}