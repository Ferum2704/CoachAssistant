using Application.Abstractions.IRepository;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class ClubRepository : GenericRepository<Club>, IClubRepository
    {
        public ClubRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
