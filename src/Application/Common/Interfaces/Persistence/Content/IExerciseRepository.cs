using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Domain.Content.Exercise;

namespace CzyDobrze.Application.Common.Interfaces.Persistence.Content
{
    public interface IExerciseRepository
    {
        Task<Exercise> ReadById(Guid id);
        Task<IEnumerable<Exercise>> ReadAll();
        
        Task Create(Exercise entity);
        Task Update(Exercise entity);
        Task Delete(Exercise entity);
    }
}