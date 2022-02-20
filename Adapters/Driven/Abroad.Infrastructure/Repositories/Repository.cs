using Abroad.Domain.Entities.Base;
using Abroad.Domain.Repositories;
using Abroad.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Abroad.Infrastructure.Repositories
{
    public class Repository<TEntity, TID> : IDisposable, IRepository<TEntity, TID> where TEntity : AggregateRoot<TID>
    {
        private readonly AbroadContext _context;

        public Repository(AbroadContext context) => _context = context;

        public async Task<TEntity> Add(TEntity entity)
        {
            await _context
                .Set<TEntity>()
                .AddAsync(entity);

            return entity;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<TEntity> Get(TID ID)
        {
            return await _context
                .Set<TEntity>()
                .FindAsync(ID)!;
        }

        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context
                .Set<TEntity>()
                .AsNoTracking();

            query = includes
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query;
        }
    }
}