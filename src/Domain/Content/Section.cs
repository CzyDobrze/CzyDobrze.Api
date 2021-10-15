using System.Collections;
using System.Collections.Generic;
using CzyDobrze.Core;

namespace CzyDobrze.Domain.Content
{
    public class Section : Entity
    {
        private readonly IList<Exercise> _exercises = new List<Exercise>();
        
        private Section()
        {
            // For EF
        }

        public Section(string title, string description)
        {
            Title = title;
            Description = description;
        }
        
        public string Title { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<Exercise> Exercises => _exercises;

        public void UpdateTitle(string title)
        {
            Title = title;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void AddExercise(Exercise exercise)
        {
            _exercises.Add(exercise);
        }

        public void DeleteExercise(Exercise exercise)
        {
            _exercises.Remove(exercise);
        }
    }
}