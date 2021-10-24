using System;
using CzyDobrze.Domain.Content.Answer;
using MediatR;

namespace CzyDobrze.Application.Answers.Commands.UpdateAnswer
{
    public class UpdateAnswer : IRequest<Answer>
    {
        public UpdateAnswer(Guid id, string content, bool accepted = false)
        {
            Id = id;
            Content = content;
            Accepted = accepted;
        }
        
        public Guid Id { get; set; }
        public string Content { get; set; }
        public bool Accepted { get; set; }
    }
}