using System;
using CzyDobrze.Domain.Content.Answer;
using MediatR;

namespace CzyDobrze.Application.Answers.Commands.CreateAnswer
{
    public class CreateAnswer : IRequest<Answer>
    {
        public CreateAnswer(string content, Guid exerciseId)
        {
            Content = content;
            ExerciseId = exerciseId;
        }

        public Guid ExerciseId { get; set; }
        public string Content { get; set; }
    }
}