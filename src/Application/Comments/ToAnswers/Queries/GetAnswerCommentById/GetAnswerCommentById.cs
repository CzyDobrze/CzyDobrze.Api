using System;
using CzyDobrze.Domain.Content.Comment;
using MediatR;

namespace CzyDobrze.Application.Comments.ToAnswers.Queries.GetAnswerCommentById
{
    public class GetAnswerCommentById : IRequest<AnswerComment>
    {
        public GetAnswerCommentById(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}