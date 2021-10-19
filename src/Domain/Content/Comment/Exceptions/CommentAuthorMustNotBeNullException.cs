using System;

namespace CzyDobrze.Domain.Content.Comment.Exceptions
{
    public class CommentAuthorMustNotBeNullException : Exception
    {
        public CommentAuthorMustNotBeNullException() : base("Comment author must not be null.")
        {
            
        }
    }
}