using FluentValidation;

namespace CzyDobrze.Application.Comments.ToAnswers.Queries.GetAllCommentsToAnswer
{
    public class GetAllCommentsToAnswerValidator : AbstractValidator<GetAllCommentsToAnswer>
    {
        public GetAllCommentsToAnswerValidator()
        {
            RuleFor(x => x.Amount)
                .InclusiveBetween(0, 100);

            RuleFor(x => x.AnswerId)
                .NotEmpty();
        }
    }
}