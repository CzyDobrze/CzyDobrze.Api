using CzyDobrze.Core;

namespace CzyDobrze.Domain.Content.Section.Exceptions
{
    public class SectionTitleMustNotBeEmptyException : DomainException
    {
        public SectionTitleMustNotBeEmptyException() : base("Section title must not be empty.")
        {
        }
    }
}