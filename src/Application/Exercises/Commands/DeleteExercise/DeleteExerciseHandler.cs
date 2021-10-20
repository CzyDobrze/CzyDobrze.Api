using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using MediatR;

namespace CzyDobrze.Application.Exercises.Commands.DeleteExercise
{
    public class DeleteExerciseHandler : IRequestHandler<DeleteExercise>
    {
        private readonly IExerciseRepository _repository;

        public DeleteExerciseHandler(IExerciseRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Unit> Handle(DeleteExercise request, CancellationToken cancellationToken)
        {
            var exercise = await _repository.ReadById(request.Id);
            if (exercise == null) throw new EntityNotFoundException();

            await _repository.Delete(exercise);
            
            return Unit.Value;
        }
    }
}