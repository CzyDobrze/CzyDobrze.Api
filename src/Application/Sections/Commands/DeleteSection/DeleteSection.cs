using System;
using MediatR;

namespace CzyDobrze.Application.Sections.Commands.DeleteSection
{
    public class DeleteSection : IRequest
    {
        public DeleteSection(Guid id)
        {
            Id = id;
        }
        
        public Guid Id { get; set; }
    }
}