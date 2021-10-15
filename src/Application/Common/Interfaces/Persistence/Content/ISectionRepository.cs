using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CzyDobrze.Domain.Content.Section;

namespace CzyDobrze.Application.Common.Interfaces.Persistence.Content
{
    public interface ISectionRepository
    {
        Task<Section> ReadById(Guid id);
        Task<IEnumerable<Section>> ReadAll();
        
        Task Create(Section entity);
        Task Update(Section entity);
        Task Delete(Section entity);
    }
}