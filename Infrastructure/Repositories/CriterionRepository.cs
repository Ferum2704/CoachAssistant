using Application.Abstractions.IRepository;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class CriterionRepository : GenericRepository<Criterion>, ICriterionRepository
    {
        public CriterionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
