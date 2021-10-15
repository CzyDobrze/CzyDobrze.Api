using CzyDobrze.Core;

namespace CzyDobrze.Domain.Content.Textbook.Exceptions
{
    public class TextbookTitleMustNotBeEmptyException : DomainException
    {
        public TextbookTitleMustNotBeEmptyException() : base("Textbook title must not be empty.")
        {
        }
    }
}