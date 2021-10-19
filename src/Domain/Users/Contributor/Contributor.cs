using CzyDobrze.Core;
using CzyDobrze.Domain.Users.Contributor.Exceptions;

namespace CzyDobrze.Domain.Users.Contributor
{
    public class Contributor : Entity
    {
        public Contributor()
        {
            // For EF
        }
        
        public string DisplayName { get; }
        public uint Points { get; private set; }

        public void AddPoints(uint points)
        {
            Points += points;
        }

        public void TakePoints(uint points)
        {
            if (points > Points) throw new CannotTakeMorePointsThanContributorHasException();
            Points -= points;
        }
    }
}