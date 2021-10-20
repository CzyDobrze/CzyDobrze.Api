using System;

namespace CzyDobrze.Domain.Content.Answer.Exceptions
{
    public class AnswerVoteMustNotBeNullException : Exception
    {
        public AnswerVoteMustNotBeNullException() : base("Answer vote must not be null.")
        {
            
        }
    }
}