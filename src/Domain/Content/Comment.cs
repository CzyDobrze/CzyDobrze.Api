using System.Collections.Generic;
using CzyDobrze.Core;
using CzyDobrze.Domain.Users;

namespace CzyDobrze.Domain.Content
{
    public class Comment : Entity
    {
        private Comment()
        {
            // For EF
        }

        public Comment(User author, string content)
        {
            Author = author;
            Content = content;
            Votes = new List<Vote>();
        }

        public User Author { get; }
        public string Content { get; }
        
        public IList<Vote> Votes { get; } // TODO wrap using IEnumerable<> to prevent direct write access
    }
}