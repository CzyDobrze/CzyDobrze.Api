using System.Collections.Generic;
using CzyDobrze.Core;
using CzyDobrze.Domain.Users;

namespace CzyDobrze.Domain.Content
{
    public class Answer : Entity
    {
        public User Author { get; }
        public string Content { get; }
        
        public bool Accepted { get; }
        
        public IEnumerable<Vote> Votes { get; }
    }
}