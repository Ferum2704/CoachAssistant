﻿using Application.Abstractions.IRepository;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        protected readonly ApplicationDbContext context;
        protected readonly DbSet<TEntity> dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter is null)
            {
                return await query.ToListAsync();
            }

            return await query.Where(filter).ToListAsync();
        }

        public async Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>>? filter, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = dbSet;

            return await dbSet.SingleOrDefaultAsync(filter, cancellationToken);
        }

        public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = dbSet;

            return await dbSet.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void Add(TEntity entity) => dbSet.Add(entity);

        public void AddRange(IEnumerable<TEntity> entities) => dbSet.AddRange(entities);

        public void Remove(TEntity entity) => dbSet.Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities) => dbSet.RemoveRange(entities);

        public void Update(TEntity entity) => dbSet.Update(entity);
    }
}
