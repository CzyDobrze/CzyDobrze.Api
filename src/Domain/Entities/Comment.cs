using System;
using CzyDobrze.Core;

namespace CzyDobrze.Domain.Entities
{
    public class Comment : Entity
    {
        public Guid AuthorId { get; }
        public string Content { get; }
    }
}