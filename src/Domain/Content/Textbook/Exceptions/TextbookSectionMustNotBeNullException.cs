using System;

namespace CzyDobrze.Domain.Content.Textbook.Exceptions
{
    public class TextbookSectionMustNotBeNullException : Exception
    {
        public TextbookSectionMustNotBeNullException() : base("Section added to textbook must not be null.")
        {
            
        }
    }
}