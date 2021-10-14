using CzyDobrze.Core;

namespace CzyDobrze.Domain.Users
{
    public class User : Entity
    {
        private User()
        {
            // For EF
        }

        public User(string displayName, int points)
        {
            DisplayName = displayName;
            Points = points;
        }
        
        public string DisplayName { get; }
        public int Points { get; }
    }
}