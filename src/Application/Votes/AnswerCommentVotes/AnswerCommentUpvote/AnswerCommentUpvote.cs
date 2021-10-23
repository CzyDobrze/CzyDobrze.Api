using System;
using MediatR;

namespace CzyDobrze.Application.Votes.AnswerCommentVotes.AnswerCommentUpvote
{
    public class AnswerCommentUpvote : IRequest
    {
        public AnswerCommentUpvote(Guid answerCommentId)
        {
            AnswerCommentId = answerCommentId;
        }
        
        public Guid AnswerCommentId { get; set; }
    }
}