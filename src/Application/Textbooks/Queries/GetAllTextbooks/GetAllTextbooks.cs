using System.Collections.Generic;
using CzyDobrze.Domain.Content.Textbook;
using MediatR;

namespace CzyDobrze.Application.Textbooks.Queries.GetAllTextbooks
{
    public class GetAllTextbooks : IRequest<IEnumerable<Textbook>>
    {
        
    }
}