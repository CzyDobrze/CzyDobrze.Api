using FluentValidation;

namespace CzyDobrze.Application.Exercises.Queries.GetAllExercisesFromSection
{
    public class GetAllExercisesFromSectionValidator : AbstractValidator<GetAllExercisesFromSection>
    {
        public GetAllExercisesFromSectionValidator()
        {
            RuleFor(x => x.SectionId)
                .NotEmpty();

            RuleFor(x => x.Amount)
                .InclusiveBetween(0, 100);
        }
    }
}