using Application.Abstractions.IRepository;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class MatchTeamRepository : GenericRepository<MatchTeam>, IMatchTeamRepository
    {
        public MatchTeamRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
