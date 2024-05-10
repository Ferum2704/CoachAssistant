using Application.Abstractions.IRepository;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class TrainingRecordRepository : GenericRepository<TrainingRecord>, ITrainingRecordRepository
    {
        public TrainingRecordRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
