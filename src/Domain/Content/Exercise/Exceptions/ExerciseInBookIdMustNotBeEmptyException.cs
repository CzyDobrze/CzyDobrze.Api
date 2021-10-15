using CzyDobrze.Core;

namespace CzyDobrze.Domain.Content.Exercise.Exceptions
{
    public class ExerciseInBookIdMustNotBeEmptyException : DomainException
    {
        public ExerciseInBookIdMustNotBeEmptyException() : base("InBookId must not be empty.")
        {
        }
    }
}