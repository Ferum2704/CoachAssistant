using Application.Abstractions.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TrainingRepository : GenericRepository<Training>, ITrainingRepository
    {
        public TrainingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public new async Task<Training?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await dbSet
            .Include(x => x.TrainingRecords)
            .ThenInclude(x => x.TrainingMarks)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
