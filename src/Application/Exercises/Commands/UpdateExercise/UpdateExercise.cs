using System;
using CzyDobrze.Domain.Content.Exercise;
using MediatR;

namespace CzyDobrze.Application.Exercises.Commands.UpdateExercise
{
    public class UpdateExercise : IRequest<Exercise>
    {
        public UpdateExercise(Guid id, string inBookId, string description)
        {
            Id = id;
            InBookId = inBookId;
            Description = description;
        }
        
        public Guid Id { get; set; }
        public string InBookId { get; set; }
        public string Description { get; set;  }
    }
}