using Application.Abstractions.IRepository;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class MatchLineupPositionRepository : GenericRepository<MatchLineupPosition>, IMatchLineupPositionRepository
    {
        public MatchLineupPositionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
