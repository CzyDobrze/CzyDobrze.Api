using System.Collections.Generic;
using CzyDobrze.Core;

namespace CzyDobrze.Domain.Content
{
    public class Textbook : Entity
    {
        private Textbook()
        {
            // For EF
        }

        public Textbook(string title, string subject, string publisher, int classYear)
        {
            Title = title;
            Subject = subject;
            Publisher = publisher;
            ClassYear = classYear;
            Sections = new List<Section>();
        }
        
        public string Title { get; }
        public string Subject { get; }
        public string Publisher { get; }
        public int ClassYear { get; }
        
        public IList<Section> Sections { get; }
    }
}