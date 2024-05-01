using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class TrainingRecordConfiguration : IEntityTypeConfiguration<TrainingRecord>
    {
        public void Configure(EntityTypeBuilder<TrainingRecord> builder)
        {
            builder.ToTable(nameof(TrainingRecord));

            builder.HasKey(t => t.Id);

            builder
                .HasMany(x => x.TrainingMarks)
                .WithOne(x => x.TrainingRecord)
                .HasForeignKey(x => x.TrainingRecordId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
