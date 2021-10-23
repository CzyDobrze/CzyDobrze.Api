using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Comment;
using MediatR;

namespace CzyDobrze.Application.Comments.ToAnswers.Commands.CreateAnswerComment
{
    public class CreateAnswerCommentHandler : IRequestHandler<CreateAnswerComment, AnswerComment>
    {
        private readonly IAnswerCommentRepository _repository;
        private readonly ICurrentUserService _userService;

        public CreateAnswerCommentHandler(IAnswerCommentRepository repository, ICurrentUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }
        
        public async Task<AnswerComment> Handle(CreateAnswerComment request, CancellationToken cancellationToken)
        {
            if (! await _userService.IsContributor())
                throw new AuthorizationException();
            
            var contributor = await _userService.GetContributor();
            var comment = new AnswerComment(contributor, request.Content);

            return await _repository.Create(request.AnswerId, comment);
        }
    }
}