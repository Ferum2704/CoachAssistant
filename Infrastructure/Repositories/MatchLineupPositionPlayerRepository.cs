using Application.Abstractions.IRepository;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class MatchLineupPositionPlayerRepository : GenericRepository<MatchLineupPositionPlayer>, IMatchLineupPositionPlayerRepository
    {
        public MatchLineupPositionPlayerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
