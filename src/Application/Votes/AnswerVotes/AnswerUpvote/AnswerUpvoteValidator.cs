using FluentValidation;

namespace CzyDobrze.Application.Votes.AnswerVotes.AnswerUpvote
{
    public class AnswerUpvoteValidator : AbstractValidator<AnswerUpvote>
    {
        public AnswerUpvoteValidator()
        {
            RuleFor(x => x.AnswerId)
                .NotEmpty();
        }
    }
}