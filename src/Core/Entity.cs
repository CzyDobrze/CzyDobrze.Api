using System;
using CzyDobrze.Core.EntityExceptions;

namespace CzyDobrze.Core
{
    public abstract class Entity 
    {
        protected Entity()
        {
            // For use with repository
        }

        protected Entity(Guid id, DateTime created, DateTime updated)
        {
            // For use in Unit Tests
            
            Id = id;
            Created = created;
            Updated = updated;
        }

        public Guid Id { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; private set; }

        public void Update(DateTime update)
        {
            if (update < Created) throw new UpdateCannotBeEarlierThanCreationException();
            if (update < Updated) throw new UpdateCannotBeEarlierThanPreviousException();
            
            Updated = update;
        }
    }
}