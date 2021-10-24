using System;
using MediatR;

namespace CzyDobrze.Application.Comments.ToExercises.Commands.DeleteExerciseComment
{
    public class DeleteExerciseComment : IRequest
    {
        public DeleteExerciseComment(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}