using System.Collections.Generic;
using CzyDobrze.Core;
using CzyDobrze.Domain.Content.Answer.Exceptions;
using CzyDobrze.Domain.Users.User;

namespace CzyDobrze.Domain.Content.Answer
{
    public class Answer : Entity
    {
        private readonly IList<Vote.Vote> _votes = new List<Vote.Vote>();
        
        private Answer()
        {
            // For EF
        }

        public Answer(User author, string content)
        {
            Author = author;
            Accepted = false;
            
            SetContent(content);
        }
        
        public User Author { get; }
        public string Content { get; private set; }
        
        public bool Accepted { get; private set; }
        
        public IEnumerable<Vote.Vote> Votes => _votes;

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

        public void AddVote(Vote.Vote vote)
        {
            _votes.Add(vote);
        }

        public void DeleteVote(Vote.Vote vote)
        {
            _votes.Remove(vote);
        }
    }
}