using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using MediatR;

namespace CzyDobrze.Application.Comments.ToAnswers.Commands.DeleteAnswerComment
{
    public class DeleteAnswerCommentValidator : IRequestHandler<DeleteAnswerComment>
    {
        private readonly IAnswerCommentRepository _commentRepository;
        private readonly ICurrentUserService _userService;

        public DeleteAnswerCommentValidator(IAnswerCommentRepository commentRepository, ICurrentUserService userService)
        {
            _commentRepository = commentRepository;
            _userService = userService;
        }
        
        public async Task<Unit> Handle(DeleteAnswerComment request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.ReadById(request.Id);
            if (comment == null) throw new EntityNotFoundException();

            if (await _userService.IsModerator())
            {
                await _commentRepository.Delete(comment);
            } else if (await _userService.IsContributor())
            {
                var contributor = await _userService.GetContributor();
                if (comment.Author.Id != contributor.Id)
                    throw new AuthorizationException();
                await _commentRepository.Delete(comment);
            }
            else throw new AuthorizationException();
            
            return Unit.Value;
        }
    }
}