using CzyDobrze.Core;
using CzyDobrze.Domain.Users.User.Exceptions;

namespace CzyDobrze.Domain.Users.User
{
    public class User : Entity
    {
        private User()
        {
            // For EF
        }

        public User(string displayName)
        {
            SetDisplayName(displayName);
        }
        
        public string DisplayName { get; private set; }

        public void SetDisplayName(string displayName)
        {
            if (string.IsNullOrWhiteSpace(displayName)) throw new UsersDisplayNameMustNotBeEmptyException();
            DisplayName = displayName;
        }
    }
}