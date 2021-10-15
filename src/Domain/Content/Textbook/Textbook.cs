using System.Collections.Generic;
using CzyDobrze.Core;
using CzyDobrze.Domain.Content.Textbook.Exceptions;

namespace CzyDobrze.Domain.Content.Textbook
{
    public class Textbook : Entity
    {
        private readonly IList<Section.Section> _sections = new List<Section.Section>();
        
        private Textbook()
        {
            // For EF
        }

        public Textbook(string title, string subject, string publisher, int classYear)
        {
            SetTitle(title);
            SetSubject(subject);
            SetPublisher(publisher);
            SetClassYear(classYear);
        }
        
        public string Title { get; private set; } 
        public string Subject { get; private set; }
        public string Publisher { get; private set; }
        public int ClassYear { get; private set; } 

        public IEnumerable<Section.Section> Sections => _sections;

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new TextbookTitleMustNotBeEmptyException();
            Title = title;
        }

        public void SetSubject(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject)) throw new TextbookSubjectMustNotBeEmptyException();
            Subject = subject;
        }

        public void SetPublisher(string publisher)
        {
            if (string.IsNullOrWhiteSpace(publisher)) throw new TextbookPublisherMustNotBeEmptyException();
            Publisher = publisher;
        }

        public void SetClassYear(int classYear)
        {
            if (classYear is < 1 or > 12) throw new TextbookClassYearInvalidException();
            ClassYear = classYear;
        }

        public void AddSection(Section.Section section)
        {
            _sections.Add(section);
        }

        public void DeleteSection(Section.Section section)
        {
            _sections.Remove(section);
        }
    }
}