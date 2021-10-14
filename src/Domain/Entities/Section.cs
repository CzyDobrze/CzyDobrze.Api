using System.Collections;
using CzyDobrze.Core;

namespace CzyDobrze.Domain.Entities
{
    public class Section : Entity
    {
        public string Title { get; }
        public string Description { get; }
        public IEnumerable Exercises { get; }
    }
}