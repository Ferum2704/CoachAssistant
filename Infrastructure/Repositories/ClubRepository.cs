using Application.Abstractions.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class ClubRepository : GenericRepository<Club>, IClubRepository
    {
        public ClubRepository(ApplicationDbContext context) : base(context)
        {
        }

        public new async Task<Club?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await dbSet.Include(x => x.Team).SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        public new async Task<IReadOnlyCollection<Club>> GetAsync(Expression<Func<Club, bool>>? filter = null, CancellationToken cancellationToken = default)
        {
            IQueryable<Club> query = dbSet.Include(x => x.Team);

            if (filter is null)
            {
                return await query.ToListAsync();
            }

            return await query.Where(filter).ToListAsync();
        }
    }
}
