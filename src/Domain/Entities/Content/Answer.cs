using System;
using System.Collections;
using System.Collections.Generic;
using CzyDobrze.Core;

namespace CzyDobrze.Domain.Entities.Content
{
    public class Answer : Entity
    {
        public Guid AuthorId { get; }
        public string Content { get; }
        
        public bool Accepted { get; }
        
        public IEnumerable<Vote> Votes { get; }
    }
}