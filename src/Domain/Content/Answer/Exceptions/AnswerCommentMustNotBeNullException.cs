using System;

namespace CzyDobrze.Domain.Content.Answer.Exceptions
{
    public class AnswerCommentMustNotBeNullException : Exception
    {
        public AnswerCommentMustNotBeNullException() : base("Comment added to answer must not be null.")
        {
            
        }
    }
}