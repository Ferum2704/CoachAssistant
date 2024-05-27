using Application.Abstractions.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class PositionRepository : GenericRepository<Position>, IPositionRepository
    {
        public PositionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public new async Task<Position?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await dbSet
            .Include(x => x.Criteria)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        public new async Task<IReadOnlyCollection<Position>> GetAsync(Expression<Func<Position, bool>>? filter = null, CancellationToken cancellationToken = default)
        {
            IQueryable<Position> query = dbSet.Include(x => x.PositionCriteria);

            if (filter is null)
            {
                return await query.ToListAsync();
            }

            return await query.Where(filter).ToListAsync();
        }
    }
}
