using System;
using CzyDobrze.Core;

namespace CzyDobrze.Domain.Content.Vote
{
    public class Vote : Entity
    {
        private Vote()
        {
            // For EF
        }
        
        private Vote(Guid voter, int value)
        {
            Voter = voter;
            Value = value;
        }

        public static Vote Upvote(Guid voter)
            => new(voter, 1);

        public static Vote Downvote(Guid voter)
            => new(voter, -1);
        
        public Guid Voter { get; }
        public int Value { get; }
    }
}