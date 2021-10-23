using System;
using CzyDobrze.Domain.Content.Comment;
using MediatR;

namespace CzyDobrze.Application.Comments.ToExercises.Queries.GetExerciseCommentById
{
    public class GetExerciseCommentById : IRequest<ExerciseComment>
    {
        public GetExerciseCommentById(Guid id)
        {
            Id = id;
        }
        
        public Guid Id { get; set; }
    }
}