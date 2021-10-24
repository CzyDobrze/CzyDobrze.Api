using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Answer;
using MediatR;

namespace CzyDobrze.Application.Answers.Queries.GetAllAnswersToExercise
{
    public class GetAllAnswersToExerciseHandler : IRequestHandler<GetAllAnswersToExercise, IEnumerable<Answer>>
    {
        private readonly IAnswerRepository _repository;

        public GetAllAnswersToExerciseHandler(IAnswerRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<Answer>> Handle(GetAllAnswersToExercise request, CancellationToken cancellationToken)
        {
            var answers = await _repository.ReadAllFromGivenExerciseId(request.ExerciseId);

            return answers
                .Skip(request.Page * request.Amount)
                .Take(request.Amount)
                .AsEnumerable();
        }
    }
}