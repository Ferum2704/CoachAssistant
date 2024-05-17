using Application.Abstractions.IRepository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class TournamentTeamRepository : GenericRepository<TournamentTeam>, ITournamentTeamRepository
    {
        public TournamentTeamRepository(ApplicationDbContext context) : base(context)
        {
        }

        public new async Task<IReadOnlyCollection<TournamentTeam>> GetAsync(Expression<Func<TournamentTeam, bool>>? filter = null, CancellationToken cancellationToken = default)
        {
            IQueryable<TournamentTeam> query = dbSet.Include(x => x.Team);

            if (filter is null)
            {
                return await query.ToListAsync();
            }

            return await query.Where(filter).ToListAsync();
        }
    }
}
