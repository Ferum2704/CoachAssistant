using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class TrainingConfiguration : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.ToTable(nameof(Training));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.Duration).HasDefaultValue(0).IsRequired();

            builder
                .HasMany(x => x.Players)
                .WithMany()
                .UsingEntity<TrainingRecord>(
                    l => l.HasOne(x => x.Player).WithMany(x => x.TrainingRecords).HasForeignKey(x => x.PlayerId).IsRequired().OnDelete(DeleteBehavior.NoAction),
                    r => r.HasOne(x => x.Training).WithMany(x => x.TrainingRecords).HasForeignKey(x => x.TrainingId).IsRequired());
        }
    }
}
