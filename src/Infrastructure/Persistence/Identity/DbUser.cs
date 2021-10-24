using System;

namespace CzyDobrze.Infrastructure.Persistence.Identity
{
    public class DbUser
    {
        public DbUser(string displayName, string auth0Id, uint points = 0, bool isContributor = false, bool isModerator = false)
        {
            DisplayName = displayName;
            Points = points;
            IsContributor = isContributor;
            IsModerator = isModerator;
            Auth0Id = auth0Id;
        }
        
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        
        public string DisplayName { get; set; }
        public uint Points { get; set; }
        
        public string Auth0Id { get; set; }
        
        public bool IsContributor { get; set; }
        public bool IsModerator { get; set; }
    }
}