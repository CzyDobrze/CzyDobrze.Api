using CzyDobrze.Core;
using CzyDobrze.Domain.Users.Contributor;

namespace CzyDobrze.Domain.Content.Vote
{
    public class ExerciseCommentVote : Entity
    {
        private ExerciseCommentVote()
        {
            // For EF
        }
        
        private ExerciseCommentVote(Contributor voter, int value)
        {
            Voter = voter;
            Value = value;
        }

        public static ExerciseCommentVote Upvote(Contributor voter)
            => new(voter, 1);

        public static ExerciseCommentVote Downvote(Contributor voter)
            => new(voter, -1);
        
        public Contributor Voter { get; }
        public int Value { get; }
    }
}