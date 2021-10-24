using System;
using CzyDobrze.Core;

namespace CzyDobrze.Domain.Users.Moderator
{
    public class Moderator : Entity
    {
        private Moderator()
        {
            // For EF
        }

        public Moderator(Guid id, DateTime created, DateTime updated) : base(id, created, updated)
        {
        }
    }
}