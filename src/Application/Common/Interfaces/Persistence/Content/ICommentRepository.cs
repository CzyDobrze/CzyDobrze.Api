using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Domain.Content.Comment;

namespace CzyDobrze.Application.Common.Interfaces.Persistence.Content
{
    public interface ICommentRepository
    {
        Task<Comment> ReadById(Guid id);
        Task<IEnumerable<Comment>> ReadAll();
        
        Task<Comment> Create(Comment entity);
        Task<Comment> Update(Comment entity);
        Task Delete(Comment entity);
    }
}