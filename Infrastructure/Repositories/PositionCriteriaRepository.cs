using Application.Abstractions.IRepository;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class PositionCriteriaRepository : GenericRepository<PositionCriteria>, IPositionCriteriaRepository
    {
        public PositionCriteriaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
