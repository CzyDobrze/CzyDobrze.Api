using FluentValidation;

namespace CzyDobrze.Application.Votes.AnswerVotes.AnswerResetVote
{
    public class AnswerResetVoteValidator : AbstractValidator<AnswerResetVote>
    {
        public AnswerResetVoteValidator()
        {
            RuleFor(x => x.AnswerId)
                .NotEmpty();
        }
    }
}