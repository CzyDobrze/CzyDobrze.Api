using System.Collections.Generic;
using CzyDobrze.Core;
using CzyDobrze.Domain.Content.Comment.Exceptions;
using CzyDobrze.Domain.Users.User;

namespace CzyDobrze.Domain.Content.Comment
{
    public class Comment : Entity
    {
        private readonly IList<Vote.Vote> _votes = new List<Vote.Vote>();
        
        private Comment()
        {
            // For EF
        }

        public Comment(User author, string content)
        {
            Author = author;
            SetContent(content);
        }

        public User Author { get; }
        public string Content { get; private set; }

        public IEnumerable<Vote.Vote> Votes => _votes;

        public void SetContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content)) throw new CommentContentMustNotBeEmptyException();
            Content = content;
        }
        
        public void AddVote(Vote.Vote vote)
        {
            if (vote is null) throw new CommentVoteMustNotBeNullException();
            _votes.Add(vote);
        }

        public void DeleteVote(Vote.Vote vote)
        {
            if (vote is null) throw new CommentVoteMustNotBeNullException();
            _votes.Remove(vote);
        }
    }
}