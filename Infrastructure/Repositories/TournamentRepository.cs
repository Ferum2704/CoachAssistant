using Application.Abstractions.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class TournamentRepository : GenericRepository<Tournament>, ITournamentRepository
    {
        public TournamentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public new async Task<Tournament?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await dbSet
            .Include(x => x.TournamentTeams)
            .Include(x => x.Matches)
            .ThenInclude(x => x.MatchTeams)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        public new async Task<IReadOnlyCollection<Tournament>> GetAsync(Expression<Func<Tournament, bool>>? filter = null, CancellationToken cancellationToken = default)
        {
            IQueryable<Tournament> query = dbSet
                .Include(x => x.Matches)
                .ThenInclude(x => x.MatchTeams)
                .ThenInclude(x => x.Team);

            if (filter is null)
            {
                return await query.ToListAsync();
            }

            return await query.Where(filter).ToListAsync();
        }
    }
}
