using FluentValidation;

namespace CzyDobrze.Application.Sections.Commands.DeleteSection
{
    public class DeleteSectionValidator : AbstractValidator<DeleteSection>
    {
        public DeleteSectionValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}