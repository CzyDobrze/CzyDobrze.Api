using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Exercise;
using MediatR;

namespace CzyDobrze.Application.Exercises.Queries.GetExerciseById
{
    public class GetExerciseByIdHandler : IRequestHandler<GetExerciseById, Exercise>
    {
        private readonly IExerciseRepository _repository;

        public GetExerciseByIdHandler(IExerciseRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Exercise> Handle(GetExerciseById request, CancellationToken cancellationToken)
        {
            var exercise = await _repository.ReadById(request.Id);

            if (exercise == null) throw new EntityNotFoundException();

            return exercise;
        }
    }
}