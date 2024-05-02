using Application.Abstractions;
using Application.Abstractions.IRepository;
using Infrastructure.Repositories;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        private IManagerRepository managerRepository;
        private IPlayerRepository playerRepository;
        private ICoachRepository coachRepository;
        private IClubRepository clubRepository;
        private ITeamRepository teamRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IManagerRepository ManagerRepository => managerRepository ??= new ManagerRepository(context);

        public ICoachRepository CoachRepository => coachRepository ??= new CoachRepository(context);

        public IPlayerRepository PlayerRepository => playerRepository ??= new PlayerRepository(context);

        public IClubRepository ClubRepository => clubRepository ??= new ClubRepository(context);

        public ITeamRepository TeamRepository => teamRepository ??= new TeamRepository(context);

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
