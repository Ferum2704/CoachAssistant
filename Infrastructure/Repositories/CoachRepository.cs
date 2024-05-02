using Application.Abstractions.IRepository;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class CoachRepository : GenericRepository<Coach>, ICoachRepository
    {
        public CoachRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
