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
        
        public string DisplayName { get; private set; }
        public int Points { get; private set; }

        public void UpdateDisplayName(string displayName)
        {
            DisplayName = displayName;
        }
        
        public void AddPoints(int points)
        {
            Points += points;
        }

        public void TakePoints(int points)
        {
            Points -= points;
        }
    }
}