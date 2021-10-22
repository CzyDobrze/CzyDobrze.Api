using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Textbook;
using Microsoft.EntityFrameworkCore;

namespace CzyDobrze.Infrastructure.Persistence.Implementations
{
    public class TextbookRepository : ITextbookRepository
    {
        private readonly AppDbContext _dbContext;

        public TextbookRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Textbook> ReadById(Guid id)
        {
            return await _dbContext.Textbooks
                .Include(x => x.Sections)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Textbook>> ReadAll()
        {
            return await _dbContext.Textbooks.ToArrayAsync();
        }

        public async Task<Textbook> Create(Textbook entity)
        {
            var create = await _dbContext.Textbooks.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            
            return create.Entity;
        }

        public async Task<Textbook> Update(Textbook entity)
        {
            var update = _dbContext.Textbooks.Update(entity);
            await _dbContext.SaveChangesAsync();

            return update.Entity;
        }

        public async Task Delete(Textbook entity)
        {
            _dbContext.Textbooks.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}