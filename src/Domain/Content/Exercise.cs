using System.Collections.Generic;
using CzyDobrze.Core;

namespace CzyDobrze.Domain.Content
{
    public class Exercise : Entity
    {
        private Exercise()
        {
            // For EF
        }

        public Exercise(string inBookId, string description)
        {
            InBookId = inBookId;
            Description = description;
            Answers = new List<Answer>();
            Comments = new List<Comment>();
        }
        
        public string InBookId { get; }
        public string Description { get; }
        
        public IList<Answer> Answers { get; }
        public IList<Comment> Comments { get; }
    }
}