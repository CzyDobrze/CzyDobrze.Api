using System;
using CzyDobrze.Domain.Content.Textbook;
using MediatR;

namespace CzyDobrze.Application.Textbooks.Queries.GetTextbookById
{
    public class GetTextbookById : IRequest<Textbook>
    {
        public GetTextbookById(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}