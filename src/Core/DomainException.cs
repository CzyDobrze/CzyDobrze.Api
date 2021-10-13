using System;

namespace CzyDobrze.Core
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
            
        }
    }

}