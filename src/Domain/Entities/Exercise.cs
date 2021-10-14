using System.Collections;
using System.Collections.Generic;
using CzyDobrze.Core;

namespace CzyDobrze.Domain.Entities
{
    public class Exercise : Entity
    {
        public string Identificator { get; }
        public string Description { get; }
        public IEnumerable<Answer> Answers { get; }
        public IEnumerable<Comment> Comments { get; }
    }
}