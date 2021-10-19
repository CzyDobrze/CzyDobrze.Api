using System;

namespace CzyDobrze.Domain.Content.Exercise.Exceptions
{
    public class ExerciseAnswerMustNotBeNullException : Exception
    {
        public ExerciseAnswerMustNotBeNullException() : base("Answer added to exercise must not be null.")
        {
            
        }
    }
}