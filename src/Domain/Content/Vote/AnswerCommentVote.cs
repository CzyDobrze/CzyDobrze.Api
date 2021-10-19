using CzyDobrze.Core;
using CzyDobrze.Domain.Users.Contributor;

namespace CzyDobrze.Domain.Content.Vote
{
    public class AnswerCommentVote : Entity
    {
        private AnswerCommentVote()
        {
            // For EF
        }
        
        private AnswerCommentVote(Contributor voter, int value)
        {
            Voter = voter;
            Value = value;
        }

        public static AnswerCommentVote Upvote(Contributor voter)
            => new(voter, 1);

        public static AnswerCommentVote Downvote(Contributor voter)
            => new(voter, -1);
        
        public Contributor Voter { get; }
        public int Value { get; }
    }
}