using System;
using MediatR;

namespace CzyDobrze.Application.Votes.AnswerCommentVotes.AnswerCommentResetVote
{
    public class AnswerCommentResetVote : IRequest
    {
        public AnswerCommentResetVote(Guid answerCommentId)
        {
            AnswerCommentId = answerCommentId;
        }
        
        public Guid AnswerCommentId { get; set; }
    }
}