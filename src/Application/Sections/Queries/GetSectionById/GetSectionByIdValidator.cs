using FluentValidation;

namespace CzyDobrze.Application.Sections.Queries.GetSectionById
{
    public class GetSectionByIdValidator : AbstractValidator<GetSectionById>
    {
        public GetSectionByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}