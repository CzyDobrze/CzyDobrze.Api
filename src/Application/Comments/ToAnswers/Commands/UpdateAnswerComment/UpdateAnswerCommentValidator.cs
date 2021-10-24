using FluentValidation;

namespace CzyDobrze.Application.Comments.ToAnswers.Commands.UpdateAnswerComment
{
    public class UpdateAnswerCommentValidator : AbstractValidator<UpdateAnswerComment>
    {
        public UpdateAnswerCommentValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty();

            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}