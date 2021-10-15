using CzyDobrze.Core;

namespace CzyDobrze.Domain.Content.Textbook.Exceptions
{
    public class TextbookClassYearInvalidException : DomainException
    {
        public TextbookClassYearInvalidException() : base("Textbook ClassYear must be between 1 and 12 inclusive.")
        {
        }
    }
}