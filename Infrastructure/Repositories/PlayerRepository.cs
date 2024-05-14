using Application.Abstractions.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
            .Include(x => x.MatchPlayerActions)
            .ThenInclude(x => x.ActionType)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
