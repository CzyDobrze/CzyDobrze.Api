﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Domain.Content.Exercise;

namespace CzyDobrze.Application.Common.Interfaces.Persistence.Content
{
    public interface IExerciseRepository
    {
        Task<Exercise> ReadById(Guid id);
        Task<IEnumerable<Exercise>> ReadAll();
        
        Task<Exercise> Create(Exercise entity);
        Task<Exercise> Update(Exercise entity);
        Task Delete(Exercise entity);
    }
}