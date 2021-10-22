using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Comment;
using MediatR;

namespace CzyDobrze.Application.Comments.ToExercises.Commands.CreateExerciseComment
{
    public class CreateExerciseHandler : IRequestHandler<CreateExerciseComment, ExerciseComment>
    {
        private readonly IExerciseCommentRepository _repository;
        private readonly ICurrentUserService _userService;

        public CreateExerciseHandler(IExerciseCommentRepository repository, ICurrentUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }
        
        public async Task<ExerciseComment> Handle(CreateExerciseComment request, CancellationToken cancellationToken)
        {
            if (!(await _userService.IsContributor() || await _userService.IsModerator()))
                throw new AuthorizationException();
            var exerciseComment = new ExerciseComment(await _userService.GetContributor(), request.Content);

            await _repository.Create(request.ExerciseId, exerciseComment);

            return exerciseComment;
        }
    }
}