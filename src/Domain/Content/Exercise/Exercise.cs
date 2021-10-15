using System.Collections.Generic;
using CzyDobrze.Core;

namespace CzyDobrze.Domain.Content.Exercise
{
    public class Exercise : Entity
    {
        private readonly IList<Answer.Answer> _answers = new List<Answer.Answer>();
        private readonly IList<Comment.Comment> _comments = new List<Comment.Comment>();
        
        private Exercise()
        {
            // For EF
        }

        public Exercise(string inBookId, string description)
        {
            InBookId = inBookId;
            Description = description;
        }
        
        public string InBookId { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<Answer.Answer> Answers => _answers;
        public IEnumerable<Comment.Comment> Comments => _comments;

        public void UpdateInBookId(string inBookId)
        {
            InBookId = inBookId;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void AddAnswer(Answer.Answer answer)
        {
            _answers.Add(answer);
        }

        public void DeleteAnswer(Answer.Answer answer)
        {
            _answers.Remove(answer);
        }

        public void AddComment(Comment.Comment comment)
        {
            _comments.Add(comment);
        }

        public void DeleteComment(Comment.Comment comment)
        {
            _comments.Remove(comment);
        }
    }
}