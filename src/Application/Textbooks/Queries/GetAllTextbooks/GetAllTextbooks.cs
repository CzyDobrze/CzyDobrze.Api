using System.Collections.Generic;
using CzyDobrze.Domain.Content.Textbook;
using MediatR;

namespace CzyDobrze.Application.Textbooks.Queries.GetAllTextbooks
{
    public class GetAllTextbooks : IRequest<IEnumerable<Textbook>>
    {
        public GetAllTextbooks(int page, int amount)
        {
            Page = page;
            Amount = amount;
        }
        
        public int Page { get; set; }
        public int Amount { get; set; }
    }
}