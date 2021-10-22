using System;
using System.Threading;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Exceptions;
using CzyDobrze.Application.Common.Interfaces;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Comment;
using MediatR;

namespace CzyDobrze.Application.Comments.ToExercises.Commands.UpdateExerciseComment
{   
    public class UpdateExerciseComment : IRequest<ExerciseComment>
    {
        public UpdateExerciseComment(Guid id, string content)
        {
            Content = content;
            Id = id;
        }
        
        public string Content { get; }
        public Guid Id { get; }
    }
}