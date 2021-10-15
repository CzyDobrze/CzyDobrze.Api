using System;

namespace CzyDobrze.Core
{
    // TODO domain level entity validation throwing specifing domain exceptions; naming review (especially all Updates - maybe it should be named Set) 
    public abstract class Entity 
    {
        protected Entity()
        {
            // For EF
        }

        protected Entity(Guid id, DateTime created, DateTime updated)
        {
            Id = id;
            Created = created;
            Updated = updated;
        }

        public Guid Id { get; } = Guid.NewGuid();
        public DateTime Created { get; }
        public DateTime Updated { get; private set; }

        public void Update(DateTime updated)
        {
            Updated = updated;
        }
    }
}