using CzyDobrze.Core;

namespace CzyDobrze.Domain.Users.Contributor.Exceptions
{
    public class CannotTakeMorePointsThanContributorHasException : DomainException
    {
        public CannotTakeMorePointsThanContributorHasException() : base("Cannot take more points than user has.")
        {
        }
    }
}