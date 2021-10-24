using System;
using MediatR;

namespace CzyDobrze.Infrastructure.Persistence.Identity
{
    public class DbUser
    {
        public DbUser(string displayName, uint points = 0, bool isContributor = false, bool isModerator = false)
        {
            DisplayName = displayName;
            Points = points;
            IsContributor = isContributor;
            IsModerator = isModerator;
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