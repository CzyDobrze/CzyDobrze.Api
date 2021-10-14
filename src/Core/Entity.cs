using System;

namespace CzyDobrze.Core
{
    // TODO add base Entity fields auto handling
    public abstract class Entity 
    {
        protected Entity()
        {
            //For EF
        }

        protected Entity(Guid id, DateTime created, DateTime updated)
        {
            Id = id;
            Created = created;
            Updated = updated;
        }
        
        public Guid Id { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; private set; }

        public void Update(DateTime updated)
        {
            Updated = updated;
        }
    }
}