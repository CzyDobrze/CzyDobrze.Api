using System;
using MediatR;

namespace CzyDobrze.Application.Exercises.Commands.DeleteExercise
{
    public class DeleteExercise : IRequest
    {
        public DeleteExercise(Guid id)
        {
            Id = id;
        }
        
        public Guid Id { get; set; }
    }
}