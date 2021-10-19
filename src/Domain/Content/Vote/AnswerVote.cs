using CzyDobrze.Core;
using CzyDobrze.Domain.Users.Contributor;

namespace CzyDobrze.Domain.Content.Vote
{
    public class AnswerVote : Entity
    {
        private AnswerVote()
        {
            // For EF
        }
        
        private AnswerVote(Contributor voter, int value)
        {
            Voter = voter;
            Value = value;
        }

        public static AnswerVote Upvote(Contributor voter)
            => new(voter, 1);

        public static AnswerVote Downvote(Contributor voter)
            => new(voter, -1);
        
        public Contributor Voter { get; }
        public int Value { get; }
    }
}