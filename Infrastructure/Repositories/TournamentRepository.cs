﻿using Application.Abstractions.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
            .ThenInclude(x => x.Team)
            .Include(x => x.Matches)
            .ThenInclude(x => x.MatchTeams)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
