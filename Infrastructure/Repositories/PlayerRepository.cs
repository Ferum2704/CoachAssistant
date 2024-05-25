using Application.Abstractions.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public new async Task<Player?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await dbSet
            .Include(x => x.TrainingRecords)
            .ThenInclude(x => x.TrainingMarks)
            .Include(x => x.MatchPlayerActions)
            .ThenInclude(x => x.ActionType)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        public new async Task<IReadOnlyCollection<Player>> GetAsync(Expression<Func<Player, bool>>? filter = null, CancellationToken cancellationToken = default)
        {
            IQueryable<Player> query = dbSet
                .Include(x => x.MatchPlayerActions)
                .Include(x => x.TrainingRecords)
                .ThenInclude(x => x.TrainingMarks);

            if (filter is null)
            {
                return await query.ToListAsync();
            }

            return await query.Where(filter).ToListAsync();
        }
    }
}
