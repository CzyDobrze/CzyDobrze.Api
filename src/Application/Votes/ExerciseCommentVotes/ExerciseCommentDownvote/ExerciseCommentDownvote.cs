using System;
using MediatR;

namespace CzyDobrze.Application.Votes.ExerciseCommentVotes.ExerciseCommentDownvote
{
    public class ExerciseCommentDownvote : IRequest
    {
        public ExerciseCommentDownvote(Guid exerciseId)
        {
            ExerciseId = exerciseId;
        }
        public Guid ExerciseId { get; set; }
    }
}