using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Exercise;
using MediatR;

namespace CzyDobrze.Application.Exercises.Commands.UpdateExercise
{
    public class UpdateExerciseHandler : IRequestHandler<UpdateExercise, Exercise>
    {
        private readonly IExerciseRepository _repository;

        public UpdateExerciseHandler(IExerciseRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Exercise> Handle(UpdateExercise request, CancellationToken cancellationToken)
        {
            var exercise = await _repository.ReadById(request.Id);
            if (exercise == null) throw new EntityNotFoundException();
            
            exercise.SetInBookId(request.InBookId);
            exercise.SetDescription(request.Description);

            return await _repository.Update(exercise);
        }
    }
}