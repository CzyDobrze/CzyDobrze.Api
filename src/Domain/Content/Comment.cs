using System.Collections.Generic;
using CzyDobrze.Core;
using CzyDobrze.Domain.Users;

namespace CzyDobrze.Domain.Content
{
    public class Comment : Entity
    {
        public User Author { get; }
        public string Content { get; }
        
        public IEnumerable<Vote> Votes { get; }
    }
}