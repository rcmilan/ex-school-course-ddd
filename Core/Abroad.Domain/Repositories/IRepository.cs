using Abroad.Domain.Entities.Base;

namespace Abroad.Domain.Repositories
{
    public interface IRepository<TEntity, TID>
        where TEntity : AggregateRoot<TID>
        where TID : Value<TID>
    {
        Task<TEntity> Add(TEntity entity);

        Task<TEntity> Get(TID ID);
    }
}
