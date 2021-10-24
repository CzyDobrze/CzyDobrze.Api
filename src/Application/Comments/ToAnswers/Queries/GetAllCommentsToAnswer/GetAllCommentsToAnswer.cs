using System;
using System.Collections.Generic;
using CzyDobrze.Domain.Content.Comment;
using MediatR;

namespace CzyDobrze.Application.Comments.ToAnswers.Queries.GetAllCommentsToAnswer
{
    public class GetAllCommentsToAnswer : IRequest<IEnumerable<AnswerComment>>
    {
        public GetAllCommentsToAnswer(Guid answerId, int page, int amount)
        {
            AnswerId = answerId;
            Page = page;
            Amount = amount;
        }
        
        public Guid AnswerId { get; set; }
        public int Page { get; set; }
        public int Amount { get; set; }
    }
}