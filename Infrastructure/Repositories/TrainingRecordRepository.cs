using Application.Abstractions.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TrainingRecordRepository : GenericRepository<TrainingRecord>, ITrainingRecordRepository
    {
        public TrainingRecordRepository(ApplicationDbContext context) : base(context)
        {
        }

        public new async Task<TrainingRecord?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await dbSet
            .Include(x => x.TrainingMarks)
            .ThenInclude(x => x.Criterion)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
