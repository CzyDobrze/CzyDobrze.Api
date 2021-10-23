using System;
using CzyDobrze.Domain.Content.Comment;
using MediatR;

namespace CzyDobrze.Application.Comments.ToAnswers.Commands.UpdateAnswerComment
{
    public class UpdateAnswerComment : IRequest<AnswerComment>
    {
        public UpdateAnswerComment(Guid id, string content)
        {
            Id = id;
            Content = content;
        }
        
        public Guid Id { get; set; }
        public string Content { get; set; } 
    }
}