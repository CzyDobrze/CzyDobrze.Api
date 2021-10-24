using FluentValidation;

namespace CzyDobrze.Application.Comments.ToAnswers.Commands.DeleteAnswerComment
{
    public class DeleteAnswerCommentHandler : AbstractValidator<DeleteAnswerComment>
    {
        public DeleteAnswerCommentHandler()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}