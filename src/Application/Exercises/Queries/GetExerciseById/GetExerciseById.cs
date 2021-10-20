using System;
using CzyDobrze.Domain.Content.Exercise;
using MediatR;

namespace CzyDobrze.Application.Exercises.Queries.GetExerciseById
{
    public class GetExerciseById : IRequest<Exercise>
    {
        public GetExerciseById(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}