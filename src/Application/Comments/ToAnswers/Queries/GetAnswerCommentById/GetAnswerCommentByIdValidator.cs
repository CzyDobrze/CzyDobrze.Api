using FluentValidation;

namespace CzyDobrze.Application.Comments.ToAnswers.Queries.GetAnswerCommentById
{
    public class GetAnswerCommentByIdValidator : AbstractValidator<GetAnswerCommentById>
    {
        public GetAnswerCommentByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}