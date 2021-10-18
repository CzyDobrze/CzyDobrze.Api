using System.Data;
using FluentValidation;

namespace CzyDobrze.Application.Sections.Commands.UpdateSection
{
    public class UpdateSectionValidator : AbstractValidator<UpdateSection>
    {
        public UpdateSectionValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.Title)
                .NotEmpty();
        }
    }
}