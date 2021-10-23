using System;
using MediatR;

namespace CzyDobrze.Application.Votes.AnswerCommentVotes.AnswerCommentDownvote
{
    public class AnswerCommentDownvote : IRequest
    {
        public AnswerCommentDownvote(Guid answerCommentId)
        {
            AnswerCommentId = answerCommentId;
        }
        
        public Guid AnswerCommentId { get; set; }
    }
}