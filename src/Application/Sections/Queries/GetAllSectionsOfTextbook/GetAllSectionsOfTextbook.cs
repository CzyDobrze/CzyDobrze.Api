using System;
using System.Collections.Generic;
using CzyDobrze.Domain.Content.Section;
using MediatR;

namespace CzyDobrze.Application.Sections.Queries.GetAllSectionsOfTextbook
{
    public class GetAllSectionsOfTextbook : IRequest<IEnumerable<Section>>
    {
        public GetAllSectionsOfTextbook(Guid textbookId, int page, int amount)
        {
            TextbookId = textbookId;
            Page = page;
            Amount = amount;
        }
        
        public Guid TextbookId { get; set; }
        public int Page { get; set; }
        public int Amount { get; set; }
    }
}