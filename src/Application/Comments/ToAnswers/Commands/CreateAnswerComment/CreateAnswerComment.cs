using System;
using CzyDobrze.Domain.Content.Comment;
using MediatR;

namespace CzyDobrze.Application.Comments.ToAnswers.Commands.CreateAnswerComment
{
    public class CreateAnswerComment : IRequest<AnswerComment>
    {
        public CreateAnswerComment(Guid answerId, string content)
        {
            AnswerId = answerId;
            Content = content;
        }
        
        public string Content { get; set; }
        public Guid AnswerId { get; set; }
    }
}