using CzyDobrze.Core;

namespace CzyDobrze.Domain.Users
{
    public class User : Entity
    {
        public string DisplayName { get; }
        public int Points { get; }
    }
}