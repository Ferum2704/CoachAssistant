using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable(nameof(Position));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();

            builder
                .HasMany(x => x.Criteria)
                .WithMany(x => x.Positions)
                .UsingEntity<PositionCriteria>(
                    l => l.HasOne(x => x.Criterion).WithMany(x => x.PositionCriteria).HasForeignKey(x => x.CriterionId).IsRequired(),
                    r => r.HasOne(x => x.Position).WithMany(x => x.PositionCriteria).HasForeignKey(x => x.PositionId).IsRequired());
        }
    }
}
