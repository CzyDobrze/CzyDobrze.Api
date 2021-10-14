using CzyDobrze.Core;

namespace CzyDobrze.Domain.Entities.Users
{
    public class User : Entity
    {
        public string DisplayName { get; }
        public int Points { get; }
    }
}