using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Comment;
using MediatR;

namespace CzyDobrze.Application.Comments.ToAnswers.Queries.GetAllCommentsToAnswer
{
    public class GetAllCommentsToAnswerHandler : IRequestHandler<GetAllCommentsToAnswer, IEnumerable<AnswerComment>>
    {
        private readonly IAnswerCommentRepository _repository;

        public GetAllCommentsToAnswerHandler(IAnswerCommentRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<AnswerComment>> Handle(GetAllCommentsToAnswer request, CancellationToken cancellationToken)
        {
            var comments = await _repository.ReadAllFromGivenAnswerId(request.AnswerId);

            return comments
                .Skip(request.Page * request.Amount)
                .Take(request.Amount)
                .AsEnumerable();
        }
    }
}