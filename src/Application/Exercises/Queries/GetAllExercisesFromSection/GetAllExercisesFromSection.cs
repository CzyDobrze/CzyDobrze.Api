using System;
using System.Collections.Generic;
using CzyDobrze.Domain.Content.Exercise;
using MediatR;

namespace CzyDobrze.Application.Exercises.Queries.GetAllExercisesFromSection
{
    public class GetAllExercisesFromSection : IRequest<IEnumerable<Exercise>>
    {
        public GetAllExercisesFromSection(Guid sectionId, int page, int amount)
        {
            SectionId = sectionId;
            Page = page;
            Amount = amount;
        }
        
        public Guid SectionId { get; set; }
        public int Page { get; set; }
        public int Amount { get; set; }
    }
}