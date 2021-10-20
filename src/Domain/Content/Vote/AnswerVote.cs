using CzyDobrze.Core;
using CzyDobrze.Domain.Content.Vote.Exceptions;
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
            Value = value;
            
            if (voter is null) throw new VotingContributorMustNotBeNullException();
            Voter = voter;
        }

        public static AnswerVote Upvote(Contributor voter)
            => new(voter, 1);

        public static AnswerVote Downvote(Contributor voter)
            => new(voter, -1);
        
        public Contributor Voter { get; }
        public int Value { get; }
        
        public Answer.Answer Answer { get; }
    }
}