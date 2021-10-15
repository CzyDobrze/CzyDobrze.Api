using CzyDobrze.Core;

namespace CzyDobrze.Domain.Content.Exercise.Exceptions
{
    public class InBookIdMustNotBeEmptyException : DomainException
    {
        public InBookIdMustNotBeEmptyException() : base("InBookId must not be empty.")
        {
        }
    }
}