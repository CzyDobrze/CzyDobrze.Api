using System.Collections.Generic;
using CzyDobrze.Core;
using CzyDobrze.Domain.Users;

namespace CzyDobrze.Domain.Content
{
    public class Comment : Entity
    {
        private readonly IList<Vote> _votes = new List<Vote>();
        
        private Comment()
        {
            // For EF
        }

        public Comment(User author, string content)
        {
            Author = author;
            Content = content;
        }

        public User Author { get; }
        public string Content { get; private set; }

        public IEnumerable<Vote> Votes => _votes;

        public void UpdateContent(string newContent)
        {
            Content = newContent;
        }
        
        public void AddVote(Vote vote)
        {
            _votes.Add(vote);
        }

        public void DeleteVote(Vote vote)
        {
            _votes.Remove(vote);
        }
    }
}