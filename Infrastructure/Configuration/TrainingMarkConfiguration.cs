using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class TrainingMarkConfiguration : IEntityTypeConfiguration<TrainingMark>
    {
        public void Configure(EntityTypeBuilder<TrainingMark> builder)
        {
            builder.ToTable(nameof(TrainingMark));

            builder.HasKey(t => t.Id);
            builder.Property(x => x.Mark).HasDefaultValue(0.0f);

            builder
                .HasOne(x => x.Criterion)
                .WithMany(x => x.TrainingMarks)
                .HasForeignKey(x => x.CriterionId)
                .IsRequired();
        }
    }
}
