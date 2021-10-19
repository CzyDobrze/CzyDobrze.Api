using System;

namespace CzyDobrze.Domain.Content.Answer.Exceptions
{
    public class AnswerAuthorMustNotBeNullException : Exception
    {
        public AnswerAuthorMustNotBeNullException() : base("Answer author must not be null.")
        {
            
        }
    }
}