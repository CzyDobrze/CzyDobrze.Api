using System.Collections.Generic;
using CzyDobrze.Core;

namespace CzyDobrze.Domain.Content
{
    public class Section : Entity
    {
        private Section()
        {
            // For EF
        }

        public Section(string title, string description)
        {
            Title = title;
            Description = description;
            Exercises = new List<Exercise>();
        }
        
        public string Title { get; }
        public string Description { get; }
        
        public IList<Exercise> Exercises { get; }
    }
}