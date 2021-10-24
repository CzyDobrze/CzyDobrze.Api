using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Comment;
using MediatR;

namespace CzyDobrze.Application.Comments.ToExercises.Queries.GetExerciseCommentById
{
    public class GetExerciseCommentByIdHandler : IRequestHandler<GetExerciseCommentById, ExerciseComment>
    {
        private readonly IExerciseCommentRepository _commentRepository;
        private readonly ICurrentUserService _userService;

        public GetExerciseCommentByIdHandler(IExerciseCommentRepository commentRepository, ICurrentUserService userService)
        {
            _commentRepository = commentRepository;
            _userService = userService;
        }
        
        public async Task<ExerciseComment> Handle(GetExerciseCommentById request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.ReadById(request.Id);
            if (comment == null) throw new EntityNotFoundException();

            return comment;
        }
    }
}