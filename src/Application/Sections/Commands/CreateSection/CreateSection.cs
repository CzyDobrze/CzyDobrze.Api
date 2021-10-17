using System;
using CzyDobrze.Domain.Content.Section;
using MediatR;

namespace  CzyDobrze.Application.Sections.Commands.CreateSection
{
    public class CreateSection : IRequest<Section>
    {
        public CreateSection(Guid textbookId, string title, string description)
        {
            TextbookId = textbookId;
            Title = title;
            Description = description;
        }
        
        public Guid TextbookId { get; set; }
        public String Title { get; set; }
        public string Description { get; set; }
    }
}