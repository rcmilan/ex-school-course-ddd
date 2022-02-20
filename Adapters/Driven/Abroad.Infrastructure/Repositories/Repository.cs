using Abroad.Domain.Entities.Base;
using Abroad.Domain.Repositories;
using Abroad.Infrastructure.Context;

namespace Abroad.Infrastructure.Repositories
{
    public class Repository<TEntity, TID> : IRepository<TEntity, TID>, IDisposable
        where TEntity : AggregateRoot<TID>
        where TID : Value<TID>
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
    }
}