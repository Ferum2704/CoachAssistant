﻿using Application.Abstractions.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MatchTeamRepository : GenericRepository<MatchTeam>, IMatchTeamRepository
    {
        public MatchTeamRepository(ApplicationDbContext context) : base(context)
        {
        }

        public new async Task<MatchTeam?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await dbSet
            .Include(x => x.LineupPositions)
            .ThenInclude(x => x.Players)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
