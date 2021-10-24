using System;

namespace CzyDobrze.Infrastructure.Persistence.Identity
{
    public class DbUser
    {
        public DbUser(string auth0Id, string displayName = "App User")
        {
            DisplayName = displayName;
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