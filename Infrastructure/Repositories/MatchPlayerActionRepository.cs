using Application.Abstractions.IRepository;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class MatchPlayerActionRepository : GenericRepository<MatchPlayerAction>, IMatchPlayerActionRepository
    {
        public MatchPlayerActionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
