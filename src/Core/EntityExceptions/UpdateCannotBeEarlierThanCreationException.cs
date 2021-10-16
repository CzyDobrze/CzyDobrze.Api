namespace CzyDobrze.Core.EntityExceptions
{
    public class UpdateCannotBeEarlierThanCreationException : DomainException
    {
        public UpdateCannotBeEarlierThanCreationException() : base("Update cannot be earlier than creation.")
        {
        }
    }
}