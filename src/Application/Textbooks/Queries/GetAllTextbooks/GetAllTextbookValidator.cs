using FluentValidation;

namespace CzyDobrze.Application.Textbooks.Queries.GetAllTextbooks
{
    public class GetAllTextbookValidator : AbstractValidator<GetAllTextbooks>
    {
        public GetAllTextbookValidator()
        {
            RuleFor(x => x.Amount)
                .InclusiveBetween(0, 100);
        }
    }
}