using CzyDobrze.Core;

namespace CzyDobrze.Domain.Content.Comment.Exceptions
{
    public class CommentContentMustNotBeEmptyException : DomainException
    {
        public CommentContentMustNotBeEmptyException() : base("Comment content must not be empty.")
        {
        }
    }
}