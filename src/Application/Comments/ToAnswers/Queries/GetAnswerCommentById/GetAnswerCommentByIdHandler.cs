using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Comment;
using MediatR;

namespace CzyDobrze.Application.Comments.ToAnswers.Queries.GetAnswerCommentById
{
    public class GetAnswerCommentByIdHandler : IRequestHandler<GetAnswerCommentById, AnswerComment>
    {
        private readonly IAnswerCommentRepository _repository;

        public GetAnswerCommentByIdHandler(IAnswerCommentRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<AnswerComment> Handle(GetAnswerCommentById request, CancellationToken cancellationToken)
        {
            var comment = await _repository.ReadById(request.Id);
            if (comment == null) throw new EntityNotFoundException();

            return comment;
        }
    }
}