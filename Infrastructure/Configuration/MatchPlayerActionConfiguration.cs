using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class MatchPlayerActionConfiguration : IEntityTypeConfiguration<MatchPlayerAction>
    {
        public void Configure(EntityTypeBuilder<MatchPlayerAction> builder)
        {
            builder.ToTable(nameof(MatchPlayerAction));

            builder.HasKey(x  => x.Id);
            builder
                .Property(x => x.ActionType)
                .HasConversion<string>()
                .IsRequired();
        }
    }
}
