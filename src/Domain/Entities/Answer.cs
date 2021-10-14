using System;
using CzyDobrze.Core;

namespace CzyDobrze.Domain.Entities
{
    public class Answer : Entity
    {
        public Guid AuthorId { get; }
        public string Content { get; }
        
        public bool Accepted { get; }
    }
}