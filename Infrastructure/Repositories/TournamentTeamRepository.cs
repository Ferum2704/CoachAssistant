using Application.Abstractions.IRepository;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class TournamentTeamRepository : GenericRepository<TournamentTeam>, ITournamentTeamRepository
    {
        public TournamentTeamRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
