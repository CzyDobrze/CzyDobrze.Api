using System;
using MediatR;

namespace CzyDobrze.Application.Votes.AnswerVotes.AnswerDownvote
{
    public class AnswerDownvote : IRequest
    {
        public AnswerDownvote(Guid answerId)
        {
            AnswerId = answerId;
        }
        public Guid AnswerId { get; set; }
    }
}