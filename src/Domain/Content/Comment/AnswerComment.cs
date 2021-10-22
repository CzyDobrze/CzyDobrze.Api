using System.Collections.Generic;
using CzyDobrze.Core;
using CzyDobrze.Domain.Content.Comment.Exceptions;
using CzyDobrze.Domain.Content.Vote;
using CzyDobrze.Domain.Users.Contributor;

namespace CzyDobrze.Domain.Content.Comment
{
    public class AnswerComment : Entity
    {
        private readonly IList<AnswerCommentVote> _votes = new List<AnswerCommentVote>();
        
        private AnswerComment()
        {
            // For EF
        }

        public AnswerComment(Contributor author, string content)
        {
            SetContent(content);

            if (author is null) throw new CommentAuthorMustNotBeNullException();
            Author = author;
        }

        public Contributor Author { get; }
        public string Content { get; private set; }

        public IEnumerable<AnswerCommentVote> Votes => _votes;

        public void SetContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content)) throw new CommentContentMustNotBeEmptyException();
            Content = content;
        }
        
        public void AddVote(AnswerCommentVote vote)
        {
            if (vote is null) throw new CommentVoteMustNotBeNullException();
            _votes.Add(vote);
        }

        public void DeleteVote(AnswerCommentVote vote)
        {
            if (vote is null) throw new CommentVoteMustNotBeNullException();
            _votes.Remove(vote);
        }
        
        // For EF (navigation property)
        public Answer.Answer Answer { get; private set; }
    }
}