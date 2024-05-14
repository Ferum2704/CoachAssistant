using Application.Abstractions.IRepository;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class TrainingMarkRepository : GenericRepository<TrainingMark>, ITrainingMarkRepository
    {
        public TrainingMarkRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
