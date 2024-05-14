using Application.Abstractions.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext context) : base(context)
        {
        }

        public new async Task<Team?> GetSingleAsync(Expression<Func<Team, bool>>? filter, CancellationToken cancellationToken = default) =>
            await dbSet
                .Include(x => x.Players)
                .Include(x => x.Trainings)
                .SingleOrDefaultAsync(filter, cancellationToken);
    }
}
