using System;

namespace CzyDobrze.Domain.Content.Vote.Exceptions
{
    public class VotingContributorMustNotBeNullException : Exception
    {
        public VotingContributorMustNotBeNullException() : base("Voting contributor must not be null.")
        {
            
        }
    }
}