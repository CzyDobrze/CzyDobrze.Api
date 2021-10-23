using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Comment;
using MediatR;

namespace CzyDobrze.Application.Comments.ToExercises.Commands.UpdateExerciseComment
{
    public class UpdateExerciseCommentHandler : IRequestHandler<UpdateExerciseComment, ExerciseComment>
    {
        private readonly IExerciseCommentRepository _repository;
        private readonly ICurrentUserService _userService;

        public UpdateExerciseCommentHandler(IExerciseCommentRepository repository, ICurrentUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public async Task<ExerciseComment> Handle(UpdateExerciseComment request, CancellationToken cancellationToken)
        {
            var comment = await _repository.ReadById(request.Id);
            if (comment == null) throw new EntityNotFoundException();

            if (await _userService.IsContributor())
            {
                var contributor = await _userService.GetContributor();
                if (contributor.Id != comment.Author.Id)
                    throw new EntityNotFoundException();
                comment.SetContent(request.Content);
            }
            else throw new AuthorizationException();

            return await _repository.Update(comment);
        }
    }
}