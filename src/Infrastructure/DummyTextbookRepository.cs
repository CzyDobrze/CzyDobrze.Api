using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CzyDobrze.Application.Common.Interfaces.Persistence.Content;
using CzyDobrze.Domain.Content.Textbook;
using Microsoft.Extensions.DependencyInjection;
using Mono.Reflection;

namespace CzyDobrze.Infrastructure
{
    /*
     * This is a dummy (writing to singleton List) textbook repository
     * which shows how it should work (uses Reflection to modify Core Entity fields - Id and Created).
     * We don't need this but may be useful as a showcase or for Unit Tests. ~~ original commit message
     *
     * Actually, as we don't have working real implementation of repository,
     * I had to merge it into main because the app won't run without it.
     *
     * When we will have persistence implementation this should be removed from 'main' branch,
     * but may be here for reference/historical purposes (branch 'bsak2003/dummy-textbook-repository')
     * or as showcase/for Unit Tests (as suggested by me originally :) 
     */
    
    internal static class DummyTextbookRepositoryDi
    {
        internal static IServiceCollection AddDummyTextbookRepository(this IServiceCollection services)
            => services.AddSingleton<ITextbookRepository, DummyTextbookRepository>();
    }
    
    public class DummyTextbookRepository : ITextbookRepository
    {
        private readonly IList<Textbook> _textbooks = new List<Textbook>();

        public Task<Textbook> ReadById(Guid id) => Task.FromResult(_textbooks.FirstOrDefault(x => x.Id == id));


        public Task<IEnumerable<Textbook>> ReadAll() => Task.FromResult(_textbooks.AsEnumerable());

        public Task<Textbook> Create(Textbook entity)
        {
            typeof(Textbook).GetProperty("Id").GetBackingField().SetValue(entity, Guid.NewGuid());
            typeof(Textbook).GetProperty("Created").GetBackingField().SetValue(entity, DateTime.UtcNow);
            entity.Update(entity.Created);
            _textbooks.Add(entity);

            return Task.FromResult(entity);
        }

        public Task<Textbook> Update(Textbook entity)
        {
            entity.Update(DateTime.UtcNow);
            _textbooks[_textbooks.IndexOf(_textbooks.FirstOrDefault(x => x.Id == entity.Id))] = entity;
            
            return Task.FromResult(entity);
        }

        public Task Delete(Textbook entity)
        {
            _textbooks.Remove(entity);

            return Task.CompletedTask;
        }
    }
}