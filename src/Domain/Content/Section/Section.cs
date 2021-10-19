using System.Collections.Generic;
using CzyDobrze.Core;
using CzyDobrze.Domain.Content.Section.Exceptions;

namespace CzyDobrze.Domain.Content.Section
{
    public class Section : Entity
    {
        private readonly IList<Exercise.Exercise> _exercises = new List<Exercise.Exercise>();
        
        private Section()
        {
            // For EF
        }

        public Section(string title, string description)
        {
            SetTitle(title);
            SetDescription(description);
        }
        
        public string Title { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<Exercise.Exercise> Exercises => _exercises;

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new SectionTitleMustNotBeEmptyException();
            Title = title;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void AddExercise(Exercise.Exercise exercise)
        {
            if (exercise is null) throw new SectionExerciseMustNotBeNullException();
            _exercises.Add(exercise);
        }

        public void DeleteExercise(Exercise.Exercise exercise)
        {
            if (exercise is null) throw new SectionExerciseMustNotBeNullException();
            _exercises.Remove(exercise);
        }
    }
}