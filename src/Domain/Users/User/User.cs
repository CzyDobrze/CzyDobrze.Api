using System;
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

        public User(Guid id, DateTime created, DateTime updated, string displayName) : base(id, created, updated)
        {
            DisplayName = displayName;
        }
        
        public string DisplayName { get; private set; }

        public void SetDisplayName(string displayName)
        {
            if (string.IsNullOrWhiteSpace(displayName)) throw new UsersDisplayNameMustNotBeEmptyException();
            DisplayName = displayName;
        }
    }
}