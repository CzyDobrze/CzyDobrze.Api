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
    // TODO remove it - this is only an example and it's only here because app won't run with no implementation at all
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