using CzyDobrze.Core;

namespace CzyDobrze.Domain.Entities
{
    public class User : Entity
    {
        public string DisplayName { get; }
        public int Points { get; }
    }
}