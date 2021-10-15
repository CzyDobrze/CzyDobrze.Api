using System.Collections.Generic;
using CzyDobrze.Core;
using CzyDobrze.Domain.Content.Exercise.Exceptions;

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
            SetInBookId(inBookId);
            SetDescription(description);
        }
        
        public string InBookId { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<Answer.Answer> Answers => _answers;
        public IEnumerable<Comment.Comment> Comments => _comments;

        public void SetInBookId(string inBookId)
        {
            if (string.IsNullOrWhiteSpace(inBookId)) throw new ExerciseInBookIdMustNotBeEmptyException();
            InBookId = inBookId;
        }

        public void SetDescription(string description)
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