using System;
using System.Collections.Generic;
using CzyDobrze.Domain.Content.Comment;
using MediatR;

namespace CzyDobrze.Application.Comments.ToExercises.Queries.GetAllCommentsToExercise
{
    public class GetAllCommentsToExercise : IRequest<IEnumerable<ExerciseComment>>
    {
        public GetAllCommentsToExercise(Guid exerciseId, int page, int amount)
        {
            ExerciseId = exerciseId;
            Page = page;
            Amount = amount;
        }
        
        public Guid ExerciseId { get; set; }
        public int Page { get; set; }
        public int Amount { get; set; }
    }
}