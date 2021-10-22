using CzyDobrze.Core;
using CzyDobrze.Domain.Content.Comment;
using CzyDobrze.Domain.Content.Vote.Exceptions;
using CzyDobrze.Domain.Users.Contributor;

namespace CzyDobrze.Domain.Content.Vote
{
    public class AnswerCommentVote : Entity
    {
        private AnswerCommentVote()
        {
            // For EF
        }
        
        private AnswerCommentVote(Contributor voter, int value)
        {
            Value = value;
            
            if (voter is null) throw new VotingContributorMustNotBeNullException();
            Voter = voter;
        }

        public static AnswerCommentVote Upvote(Contributor voter)
            => new(voter, 1);

        public static AnswerCommentVote Downvote(Contributor voter)
            => new(voter, -1);
        
        public Contributor Voter { get; }
        public int Value { get; }
        
        // For EF (navigation property)
        public AnswerComment Comment { get; private set; }
    }
}