using System.Collections.Generic;
using CzyDobrze.Core;
using CzyDobrze.Domain.Content.Answer.Exceptions;
using CzyDobrze.Domain.Content.Comment;
using CzyDobrze.Domain.Content.Vote;
using CzyDobrze.Domain.Users.Contributor;

namespace CzyDobrze.Domain.Content.Answer
{
    public class Answer : Entity
    {
        private readonly IList<AnswerComment> _comments = new List<AnswerComment>();
        private readonly IList<AnswerVote> _votes = new List<AnswerVote>();
        
        private Answer()
        {
            // For EF
        }

        public Answer(Contributor author, string content)
        {
            Accepted = false;
            
            SetContent(content);

            if (author is null) throw new AnswerAuthorMustNotBeNullException();
            Author = author;
        }
        
        public Contributor Author { get; init; }
        public string Content { get; private set; }
        
        public bool Accepted { get; private set; }

        public IEnumerable<AnswerComment> AnswerComments => _comments;
        public IEnumerable<AnswerVote> Votes => _votes;

        public void SetContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content)) throw new AnswerContentMustNotBeEmptyException();
            Content = content;
        }

        public void Accept()
        {
            Accepted = true;
        }

        public void Reject()
        {
            Accepted = false;
        }
        
        public void AddComment(AnswerComment comment)
        {
            if (comment is null) throw new AnswerCommentMustNotBeNullException();
            _comments.Add(comment);
        }
        
        public void DeleteComment(AnswerComment comment)
        {
            if (comment is null) throw new AnswerCommentMustNotBeNullException();
            _comments.Remove(comment);
        }

        public void AddVote(AnswerVote vote)
        {
            if (vote is null) throw new AnswerVoteMustNotBeNullException();
            _votes.Add(vote);
        }

        public void DeleteVote(AnswerVote vote)
        {
            if (vote is null) throw new AnswerVoteMustNotBeNullException();
            _votes.Remove(vote);
        }
        
        // For EF (navigation property)
        public Exercise.Exercise Exercise { get; private set; }
    }
}