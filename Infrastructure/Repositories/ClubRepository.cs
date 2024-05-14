using Application.Abstractions.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ClubRepository : GenericRepository<Club>, IClubRepository
    {
        public ClubRepository(ApplicationDbContext context) : base(context)
        {
        }

        public new async Task<Club?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await dbSet.Include(x => x.Team).SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
