using CzyDobrze.Core;

namespace CzyDobrze.Domain.Users.User.Exceptions
{
    public class CannotTakeMorePointsThanUserHasException : DomainException
    {
        public CannotTakeMorePointsThanUserHasException() : base("Cannot take more points than user has.")
        {
        }
    }
}