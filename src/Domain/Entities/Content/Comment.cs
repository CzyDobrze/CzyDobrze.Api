using System;
using System.Collections.Generic;
using CzyDobrze.Core;
using CzyDobrze.Domain.Entities.Users;

namespace CzyDobrze.Domain.Entities.Content
{
    public class Comment : Entity
    {
        public User Author { get; }
        public string Content { get; }
        
        public IEnumerable<Vote> Votes { get; }
    }
}