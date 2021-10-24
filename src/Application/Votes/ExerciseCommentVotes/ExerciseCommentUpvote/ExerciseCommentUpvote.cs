using System;
using MediatR;

namespace CzyDobrze.Application.Votes.ExerciseCommentVotes.ExerciseCommentUpvote
{
    public class ExerciseCommentUpvote : IRequest
    {
        public ExerciseCommentUpvote(Guid exerciseId)
        {
            ExerciseId = exerciseId;
        }
        public Guid ExerciseId { get; set; }
    }
}