using System;
using CzyDobrze.Domain.Content.Section;
using MediatR;

namespace CzyDobrze.Application.Sections.Queries.GetSectionById
{
    public class GetSectionById : IRequest<Section>
    {
        public GetSectionById(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}