using Abroad.Domain.Entities.Base;
using System.Linq.Expressions;

namespace Abroad.Domain.Repositories
{
    public interface IRepository<TEntity, TID> where TEntity : AggregateRoot<TID>
    {
        Task<TEntity> Add(TEntity entity);

        Task<TEntity> Get(TID ID);

        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);
    }
}