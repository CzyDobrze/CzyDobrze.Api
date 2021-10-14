using System;
using System.Collections.Generic;
using CzyDobrze.Core;

namespace CzyDobrze.Domain.Entities.Content
{
    public class Comment : Entity
    {
        public Guid AuthorId { get; }
        public string Content { get; }
        
        public IEnumerable<Vote> Votes { get; }
    }
}