namespace CzyDobrze.Core.EntityExceptions
{
    public class UpdateCannotBeEarlierThanPreviousException : DomainException
    {
        public UpdateCannotBeEarlierThanPreviousException() : base("Update cannot be earlier than previous one.")
        {
        }
    }
}