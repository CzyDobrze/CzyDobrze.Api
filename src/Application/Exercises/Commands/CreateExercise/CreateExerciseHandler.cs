using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Exercise;
using MediatR;

namespace CzyDobrze.Application.Exercises.Commands.CreateExercise
{
    public class CreateExerciseHandler : IRequestHandler<CreateExercise, Exercise>
    {
        private readonly IExerciseRepository _repository;

        public CreateExerciseHandler(IExerciseRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Exercise> Handle(CreateExercise request, CancellationToken cancellationToken)
        {
            return await _repository.Create(request.SectionId, new Exercise(request.InBookId, request.Description));
        }
    }
}