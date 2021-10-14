using System.Collections.Generic;
using CzyDobrze.Core;

namespace CzyDobrze.Domain.Entities.Content
{
    public class Textbook : Entity
    {
        public string Title { get; }
        public string Subject { get; }
        public string Publisher { get; }
        public int ClassYear { get; }
        
        public IEnumerable<Section> Sections { get; }
    }
}