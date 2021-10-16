using CzyDobrze.Core;

namespace CzyDobrze.Domain.Content.Answer.Exceptions
{
    public class AnswerContentMustNotBeEmptyException : DomainException
    {
        public AnswerContentMustNotBeEmptyException() : base("Answer content must not be empty.")
        {
        }
    }
}