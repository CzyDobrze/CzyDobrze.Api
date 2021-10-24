using System;
using MediatR;

namespace CzyDobrze.Application.Votes.ExerciseCommentVotes.ExerciseCommentResetVote
{
    public class ExerciseCommentResetVote : IRequest
    {
        public ExerciseCommentResetVote(Guid exerciseId)
        {
            ExerciseId = exerciseId;
        }
        public Guid ExerciseId { get; set; }
    }
}