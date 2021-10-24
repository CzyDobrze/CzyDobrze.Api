using FluentValidation;

namespace CzyDobrze.Application.Votes.AnswerCommentVotes.AnswerCommentUpvote
{
    public class AnswerCommentUpvoteValidator : AbstractValidator<AnswerCommentUpvote>
    {
        public AnswerCommentUpvoteValidator()
        {
            RuleFor(x => x.AnswerCommentId)
                .NotEmpty();
        }
    }
}