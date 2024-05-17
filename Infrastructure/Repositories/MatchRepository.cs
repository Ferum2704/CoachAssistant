using Application.Abstractions.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MatchRepository : GenericRepository<Match>, IMatchRepository
    {
        public MatchRepository(ApplicationDbContext context) : base(context)
        {
        }

        public new async Task<Match?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await dbSet
            .Include(x => x.PlayerActions)
            .ThenInclude(x => x.ActionType)
            .Include(x => x.MatchTeams)
            .ThenInclude(x => x.LineupPositions)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
