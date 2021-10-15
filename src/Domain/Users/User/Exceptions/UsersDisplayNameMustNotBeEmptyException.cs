using CzyDobrze.Core;

namespace CzyDobrze.Domain.Users.User.Exceptions
{
    public class UsersDisplayNameMustNotBeEmptyException : DomainException
    {
        public UsersDisplayNameMustNotBeEmptyException() : base("User's DisplayName must not be empty.")
        {
        }
    }
}