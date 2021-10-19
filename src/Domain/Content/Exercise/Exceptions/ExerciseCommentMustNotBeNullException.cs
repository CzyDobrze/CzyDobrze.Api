using System;

namespace CzyDobrze.Domain.Content.Exercise.Exceptions
{
    public class ExerciseCommentMustNotBeNullException : Exception
    {
        public ExerciseCommentMustNotBeNullException() : base("Comment added to exercise must not be null.")
        {
            
        }
    }
}