using CzyDobrze.Domain.Content.Textbook;
using MediatR;

namespace CzyDobrze.Application.Textbooks.Commands.CreateTextbook
{
    public class CreateTextbook : IRequest<Textbook>
    {
        public CreateTextbook(string title, string subject, string publisher, int classYear)
        {
            Title = title;
            Subject = subject;
            Publisher = publisher;
            ClassYear = classYear;
        }
        
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Publisher { get; set; }
        public int ClassYear { get; set; }
    }
}