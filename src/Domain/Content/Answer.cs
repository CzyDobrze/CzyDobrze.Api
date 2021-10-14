using System.Collections.Generic;
using CzyDobrze.Core;
using CzyDobrze.Domain.Users;

namespace CzyDobrze.Domain.Content
{
    public class Answer : Entity
    {
        private Answer()
        {
            // For EF
        }

        public Answer(User author, string content)
        {
            Author = author;
            Content = content;
            Accepted = false;
            Votes = new List<Vote>();
        }
        
        public User Author { get; }
        public string Content { get; }
        
        public bool Accepted { get; }
        
        public IList<Vote> Votes { get; }
    }
}