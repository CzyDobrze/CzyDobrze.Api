using System;
using CzyDobrze.Core;
using CzyDobrze.Domain.Enums;

namespace CzyDobrze.Domain.Entities.Content
{
    public class Vote : Entity
    {
        public Vote(Guid voter, VoteType type)
        {
            Voter = voter;
            Type = type;
        }
        
        public Guid Voter { get; }
        public VoteType Type { get; }
    }
}