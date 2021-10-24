using System;
using System.Collections.Generic;
using CzyDobrze.Domain.Content.Answer;
using MediatR;

namespace CzyDobrze.Application.Answers.Queries.GetAllAnswersToExercise
{
    public class GetAllAnswersToExercise : IRequest<IEnumerable<Answer>>
    {
        public GetAllAnswersToExercise(Guid exerciseId,int page, int amount)
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