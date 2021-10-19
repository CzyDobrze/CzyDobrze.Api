using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Domain.Content.Answer;
using CzyDobrze.Domain.Content.Comment;
using CzyDobrze.Domain.Content.Exercise;

namespace CzyDobrze.Application.Common.Interfaces.Persistence.Content
{
    public interface IExerciseCommentRepository
    {
        Task<ExerciseComment> ReadById(Guid id);
        Task<IEnumerable<ExerciseComment>> ReadAllFromGivenExerciseId(Guid id);
        
        Task<ExerciseComment> Create(Guid parentId, ExerciseComment entity);
        Task<ExerciseComment> Update(ExerciseComment entity);
        Task Delete(ExerciseComment entity);
    }
}