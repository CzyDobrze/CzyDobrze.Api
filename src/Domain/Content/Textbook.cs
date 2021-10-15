using System.Collections.Generic;
using CzyDobrze.Core;

namespace CzyDobrze.Domain.Content
{
    public class Textbook : Entity
    {
        private readonly IList<Section> _sections = new List<Section>();
        
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
        }
        
        public string Title { get; private set; } 
        public string Subject { get; private set; } // should it have its own Entity/VO? 
        public string Publisher { get; private set; } // same as Subject? 
        public int ClassYear { get; private set; } // we'll just use classes from 1 to 12

        public IEnumerable<Section> Sections => _sections;

        public void UpdateTitle(string title)
        {
            Title = title;
        }

        public void UpdateSubject(string subject)
        {
            Subject = subject;
        }

        public void UpdatePublisher(string publisher)
        {
            Publisher = publisher;
        }

        public void UpdateClassYear(int classYear)
        {
            ClassYear = classYear;
        }

        public void AddSection(Section section)
        {
            _sections.Add(section);
        }

        public void DeleteSection(Section section)
        {
            _sections.Remove(section);
        }
    }
}