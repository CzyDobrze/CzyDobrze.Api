using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Domain.Content.Section;
using CzyDobrze.Domain.Content.Textbook;

namespace CzyDobrze.Application.Common.Interfaces.Persistence.Content
{
    public interface ISectionRepository
    {
        Task<Section> ReadById(Guid id);
        Task<IEnumerable<Section>> ReadAllFromGivenTextbookId(Guid id);
        
        Task<Section> Create(Guid parentId, Section entity);
        Task<Section> Update(Section entity);
        Task Delete(Section entity);
    }
}