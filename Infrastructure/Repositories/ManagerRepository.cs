using Application.Abstractions.IRepository;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class ManagerRepository : GenericRepository<Manager>, IManagerRepository
    {
        public ManagerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
