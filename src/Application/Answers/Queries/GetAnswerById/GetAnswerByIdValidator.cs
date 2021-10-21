using FluentValidation;

namespace CzyDobrze.Application.Answers.Queries.GetAnswerById
{
    public class GetAnswerByIdValidator : AbstractValidator<GetAnswerById>
    {
        public GetAnswerByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}