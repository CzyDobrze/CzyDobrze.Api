using FluentValidation;

namespace CzyDobrze.Application.Comments.ToAnswers.Commands.CreateAnswerComment
{
    public class CreateAnswerCommentValidator : AbstractValidator<CreateAnswerComment>
    {
        public CreateAnswerCommentValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty();

            RuleFor(x => x.AnswerId)
                .NotEmpty();
        }
    }
}