using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class MatchTeamConfiguration : IEntityTypeConfiguration<MatchTeam>
    {
        public void Configure(EntityTypeBuilder<MatchTeam> builder)
        {
            builder.ToTable(nameof(MatchTeam));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.TeamType)
                .HasConversion<string>()
                .IsRequired();

            builder
                .HasMany(x => x.LineupPositions)
                .WithOne(x => x.Match)
                .HasForeignKey(x => x.MatchTeamId)
                .IsRequired();
        }
    }
}
