using System;
using CzyDobrze.Domain.Content.Comment;
using MediatR;

namespace CzyDobrze.Application.Comments.ToExercises.Commands.CreateExerciseComment
{
    public class CreateExerciseComment : IRequest<ExerciseComment>
    {
        public CreateExerciseComment(Guid exerciseId, string content)
        {
            ExerciseId = exerciseId;
            Content = content;
        }
        public Guid ExerciseId { get; private set; }
        public string Content { get; private  set; }
    }
}