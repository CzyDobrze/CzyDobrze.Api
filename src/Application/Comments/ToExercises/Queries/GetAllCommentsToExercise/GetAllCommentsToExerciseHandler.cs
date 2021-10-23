using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Comment;
using MediatR;

namespace CzyDobrze.Application.Comments.ToExercises.Queries.GetAllCommentsToExercise
{
    public class GetAllCommentsToExerciseHandler : IRequestHandler<GetAllCommentsToExercise, IEnumerable<ExerciseComment>>
    {
        private readonly IExerciseCommentRepository _repository;

        public GetAllCommentsToExerciseHandler(IExerciseCommentRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<ExerciseComment>> Handle(GetAllCommentsToExercise request, CancellationToken cancellationToken)
        {
            var allComments = await _repository.ReadAllFromGivenExerciseId(request.ExerciseId);

            return allComments
                .Skip(request.Page * request.Amount)
                .Take(request.Amount)
                .AsEnumerable();
        }
    }
}