using FluentValidation;

namespace CzyDobrze.Application.Votes.AnswerVotes.AnswerDownvote
{
    public class AnswerDownvoteValidator : AbstractValidator<AnswerDownvote>
    {
        public AnswerDownvoteValidator()
        {
            RuleFor(x => x.AnswerId)
                .NotEmpty();
        }
    }
}