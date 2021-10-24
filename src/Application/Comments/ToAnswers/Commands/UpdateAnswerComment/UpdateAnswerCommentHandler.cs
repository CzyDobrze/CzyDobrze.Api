using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Comment;
using MediatR;

namespace CzyDobrze.Application.Comments.ToAnswers.Commands.UpdateAnswerComment
{
    public class UpdateAnswerCommentHandler : IRequestHandler<UpdateAnswerComment, AnswerComment>
    {
        private readonly ICurrentUserService _userService;
        private readonly IAnswerCommentRepository _commentRepository;

        public UpdateAnswerCommentHandler(IAnswerCommentRepository commentRepository, ICurrentUserService userService)
        {
            _userService = userService;
            _commentRepository = commentRepository;
        }
        
        public async Task<AnswerComment> Handle(UpdateAnswerComment request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.ReadById(request.Id);
            if (comment == null) throw new EntityNotFoundException();

            if (!await _userService.IsContributor())
                throw new AuthorizationException();

            var contributor = await _userService.GetContributor();
            if (comment.Author.Id != contributor.Id)
                throw new AuthorizationException();
            
            comment.SetContent(request.Content);

            return await _commentRepository.Update(comment);
        }
    }
}