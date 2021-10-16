using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Domain.Content.Textbook;

namespace CzyDobrze.Application.Common.Interfaces.Persistence.Content
{
    public interface ITextbookRepository
    {
        Task<Textbook> ReadById(Guid id);
        Task<IEnumerable<Textbook>> ReadAll();
        
        Task<Textbook> Create(Textbook entity);
        Task<Textbook> Update(Textbook entity);
        Task Delete(Textbook entity);
    }
}