using System;
using CzyDobrze.Core;

namespace CzyDobrze.Domain.Entities.Content
{
    public class Vote : Entity
    {
        public Vote(Guid voter, int value)
        {
            Voter = voter;
            Value = value;
        }
        
        public Guid Voter { get; }
        public int Value { get; }
    }
}