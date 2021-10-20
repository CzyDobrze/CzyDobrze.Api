using System;
using CzyDobrze.Domain.Content.Exercise;
using MediatR;

namespace CzyDobrze.Application.Exercises.Commands.CreateExercise
{
    public class CreateExercise : IRequest<Exercise>
    {
        public CreateExercise(Guid sectionId, string inBookId, string description)
        {
            SectionId = sectionId;
            InBookId = inBookId;
            Description = description;
        }
        
        public Guid SectionId { get; set; }
        public string InBookId { get; set; }
        public string Description { get; set; }
    }
}