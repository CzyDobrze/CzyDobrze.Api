using System;
using MediatR;

namespace CzyDobrze.Application.Votes.AnswerVotes.AnswerUpvote
{
    public class AnswerUpvote : IRequest
    {
        public AnswerUpvote(Guid answerId)
        {
            AnswerId = answerId;
        }
        public Guid AnswerId { get; set; }
    }
}