using Application.Abstractions.IRepository;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
