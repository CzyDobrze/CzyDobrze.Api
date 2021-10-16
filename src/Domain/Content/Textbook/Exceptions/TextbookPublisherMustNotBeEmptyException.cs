using CzyDobrze.Core;

namespace CzyDobrze.Domain.Content.Textbook.Exceptions
{
    public class TextbookPublisherMustNotBeEmptyException : DomainException
    {
        public TextbookPublisherMustNotBeEmptyException() : base("Textbook publisher must not be empty.")
        {
        }
    }
}