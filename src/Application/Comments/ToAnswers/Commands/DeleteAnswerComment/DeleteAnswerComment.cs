using System;
using MediatR;

namespace CzyDobrze.Application.Comments.ToAnswers.Commands.DeleteAnswerComment
{
    public class DeleteAnswerComment : IRequest
    {
        public DeleteAnswerComment(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}