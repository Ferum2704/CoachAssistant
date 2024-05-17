using Domain.Interfaces;
using System.Linq.Expressions;

namespace Application.Abstractions.IRepository
{
    public interface IGenericRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        Task<IReadOnlyCollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null, CancellationToken cancellationToken = default);

        Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>>? filter, CancellationToken cancellationToken = default);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
