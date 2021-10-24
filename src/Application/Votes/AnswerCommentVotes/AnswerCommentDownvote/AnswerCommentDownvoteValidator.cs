using FluentValidation;

namespace CzyDobrze.Application.Votes.AnswerCommentVotes.AnswerCommentDownvote
{
    public class AnswerCommentDownvoteValidator : AbstractValidator<AnswerCommentDownvote>
    {
        public AnswerCommentDownvoteValidator()
        {
            RuleFor(x => x.AnswerCommentId)
                .NotEmpty();
        }
    }
}