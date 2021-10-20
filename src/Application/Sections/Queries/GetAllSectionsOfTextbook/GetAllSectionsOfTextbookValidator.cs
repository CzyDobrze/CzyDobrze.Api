using FluentValidation;

namespace CzyDobrze.Application.Sections.Queries.GetAllSectionsOfTextbook
{
    public class GetAllSectionsValidator : AbstractValidator<GetAllSectionsOfTextbook>
    {
        public GetAllSectionsValidator()
        {
            RuleFor(x => x.Amount)
                .InclusiveBetween(0, 100);

            RuleFor(x => x.TextbookId)
                .NotEmpty();
        }
    }
}