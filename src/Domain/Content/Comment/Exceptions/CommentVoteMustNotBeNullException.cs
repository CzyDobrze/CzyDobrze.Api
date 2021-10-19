using System;

namespace CzyDobrze.Domain.Content.Comment.Exceptions
{
    public class CommentVoteMustNotBeNullException : Exception
    {
        public CommentVoteMustNotBeNullException() : base("Comment vote must not be null.")
        {
            
        }
    }
}