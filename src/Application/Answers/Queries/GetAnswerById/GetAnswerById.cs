using System;
using CzyDobrze.Domain.Content.Answer;
using MediatR;

namespace CzyDobrze.Application.Answers.Queries.GetAnswerById
{
    public class GetAnswerById : IRequest<Answer>
    {
        public GetAnswerById(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}