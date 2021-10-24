using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Section;
using Microsoft.EntityFrameworkCore;

namespace CzyDobrze.Infrastructure.Persistence.Implementations.Content
{
    public class SectionRepository : ISectionRepository
    {
        private readonly AppDbContext _dbContext;

        public SectionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Section> ReadById(Guid id)
        {
            return await _dbContext.Sections
                .Include(x => x.Exercises)
                .Include(x => x.Textbook)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Section>> ReadAllFromGivenTextbookId(Guid id)
        {
            return await _dbContext.Textbooks
                .Where(x => x.Id == id)
                .Select(x => x.Sections)
                .FirstOrDefaultAsync();
        }

        public async Task<Section> Create(Guid parentId, Section entity)
        {
            var parent = await _dbContext.Textbooks.FindAsync(parentId);
            
            parent.AddSection(entity);
            
            var update = _dbContext.Textbooks.Update(parent);
            await _dbContext.SaveChangesAsync();

            return update.Entity.Sections.First();
        }

        public async Task<Section> Update(Section entity)
        {
            var update = _dbContext.Sections.Update(entity);
            await _dbContext.SaveChangesAsync();

            return update.Entity;
        }

        public async Task Delete(Section entity)
        {
            _dbContext.Sections.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}