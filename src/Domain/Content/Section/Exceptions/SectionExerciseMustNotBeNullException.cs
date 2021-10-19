using System;

namespace CzyDobrze.Domain.Content.Section.Exceptions
{
    public class SectionExerciseMustNotBeNullException : Exception
    {
        public SectionExerciseMustNotBeNullException() : base("Exercise added to section must not be null.")
        {
            
        }
    }
}