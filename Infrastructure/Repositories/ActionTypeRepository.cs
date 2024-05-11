using Application.Abstractions.IRepository;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class ActionTypeRepository : GenericRepository<ActionType>, IActionTypeRepository
    {
        public ActionTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
