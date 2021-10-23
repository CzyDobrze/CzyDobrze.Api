using FluentValidation;

namespace CzyDobrze.Application.Votes.AnswerCommentVotes.AnswerCommentResetVote
{
    public class AnswerCommentResetVoteValidator : AbstractValidator<AnswerCommentResetVote>
    {
        public AnswerCommentResetVoteValidator()
        {
            RuleFor(x => x.AnswerCommentId)
                .NotEmpty();
        }
    }
}