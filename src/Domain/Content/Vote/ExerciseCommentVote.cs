using CzyDobrze.Core;
using CzyDobrze.Domain.Content.Comment;
using CzyDobrze.Domain.Content.Vote.Exceptions;
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
            Value = value;
            
            if (voter is null) throw new VotingContributorMustNotBeNullException();
            Voter = voter;
        }

        public static ExerciseCommentVote Upvote(Contributor voter)
            => new(voter, 1);

        public static ExerciseCommentVote Downvote(Contributor voter)
            => new(voter, -1);
        
        public Contributor Voter { get; }
        public int Value { get; }
        
        public ExerciseComment Comment { get; }
    }
}