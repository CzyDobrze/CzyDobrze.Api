using CzyDobrze.Core;

namespace CzyDobrze.Domain.Content.Textbook.Exceptions
{
    public class TextbookSubjectMustNotBeEmptyException : DomainException
    {
        public TextbookSubjectMustNotBeEmptyException() : base("Textbook subject must not be empty.")
        {
        }
    }
}