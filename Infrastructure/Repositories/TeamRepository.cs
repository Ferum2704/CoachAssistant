using Application.Abstractions.IRepository;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
