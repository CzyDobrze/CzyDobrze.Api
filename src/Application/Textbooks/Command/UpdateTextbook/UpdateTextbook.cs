using System;
using CzyDobrze.Domain.Content.Textbook;
using MediatR;

namespace CzyDobrze.Application.Textbooks.Command.UpdateTextbook
{
    public class UpdateTextbook : IRequest<Textbook>
    {
        public UpdateTextbook(Guid id, string title, string subject, string publisher, int classYear)
        {
            Id = id;
            Title = title;
            Subject = subject;
            Publisher = publisher;
            ClassYear = classYear;
        }
        
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Publisher { get; set; }
        public int ClassYear { get; set; }
    }
}