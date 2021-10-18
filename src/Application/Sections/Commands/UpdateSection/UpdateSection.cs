using System;
using CzyDobrze.Domain.Content.Section;
using MediatR;

namespace CzyDobrze.Application.Sections.Commands.UpdateSection
{
    public class UpdateSection : IRequest<Section>
    {
        public UpdateSection(Guid id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
        
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}