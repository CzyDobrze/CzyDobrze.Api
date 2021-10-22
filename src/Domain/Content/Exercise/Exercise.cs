using System.Collections.Generic;
using CzyDobrze.Core;
using CzyDobrze.Domain.Content.Comment;
using CzyDobrze.Domain.Content.Exercise.Exceptions;

namespace CzyDobrze.Domain.Content.Exercise
{
    public class Exercise : Entity
    {
        private readonly IList<Answer.Answer> _answers = new List<Answer.Answer>();
        private readonly IList<ExerciseComment> _comments = new List<ExerciseComment>();
        
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
        public IEnumerable<ExerciseComment> Comments => _comments;

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
            if (answer is null) throw new ExerciseAnswerMustNotBeNullException();
            _answers.Add(answer);
        }

        public void DeleteAnswer(Answer.Answer answer)
        {
            if (answer is null) throw new ExerciseAnswerMustNotBeNullException();
            _answers.Remove(answer);
        }

        public void AddComment(ExerciseComment comment)
        {
            if (comment is null) throw new ExerciseCommentMustNotBeNullException();
            _comments.Add(comment);
        }

        public void DeleteComment(ExerciseComment comment)
        {
            if (comment is null) throw new ExerciseCommentMustNotBeNullException();
            _comments.Remove(comment);
        }
        
        // For EF (navigation property)
        public Section.Section Section { get; private set; }
    }
}