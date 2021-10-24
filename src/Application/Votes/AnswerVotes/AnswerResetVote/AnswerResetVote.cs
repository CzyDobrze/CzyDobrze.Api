using System;
using MediatR;

namespace CzyDobrze.Application.Votes.AnswerVotes.AnswerResetVote
{
    public class AnswerResetVote : IRequest
    {
        public AnswerResetVote(Guid answerId)
        {
            AnswerId = answerId;
        }
        public Guid AnswerId { get; set; }
    }
}