using System.Collections.Generic;
using CzyDobrze.Core;

namespace CzyDobrze.Domain.Entities.Content
{
    public class Exercise : Entity
    {
        public string InBookId { get; }
        public string Description { get; }
        
        public IEnumerable<Answer> Answers { get; }
        public IEnumerable<Comment> Comments { get; }
    }
}