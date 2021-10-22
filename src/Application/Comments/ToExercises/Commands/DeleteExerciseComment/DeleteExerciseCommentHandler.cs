using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using MediatR;

namespace CzyDobrze.Application.Comments.ToExercises.Commands.DeleteExerciseComment
{
    public class DeleteExerciseCommentHandler : IRequestHandler<DeleteExerciseComment>
    {
        private readonly IExerciseCommentRepository _repository;
        private readonly ICurrentUserService _currentUser;

        public DeleteExerciseCommentHandler(IExerciseCommentRepository repository, ICurrentUserService currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
        }
        
        public async Task<Unit> Handle(DeleteExerciseComment request, CancellationToken cancellationToken)
        {
            var comment = await _repository.ReadById(request.Id);
            if (comment == null) throw new EntityNotFoundException();

            if (await _currentUser.IsModerator())
            {
                await _repository.Delete(comment);
            } else if (await _currentUser.IsContributor())
            {
                var contributor = await _currentUser.GetContributor();
                if(comment.Author.Id != contributor.Id) 
                    throw new EntityNotFoundException();
                await _repository.Delete(comment);
            }
            else throw new EntityNotFoundException();
            
            return Unit.Value;
        }
    }
}