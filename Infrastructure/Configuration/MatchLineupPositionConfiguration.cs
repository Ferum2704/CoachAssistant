using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class MatchLineupPositionConfiguration : IEntityTypeConfiguration<MatchLineupPosition>
    {
        public void Configure(EntityTypeBuilder<MatchLineupPosition> builder)
        {
            builder.ToTable(nameof(MatchLineupPosition));

            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.Players)
                .WithMany(x => x.MatchLineupPositions)
                .UsingEntity<MatchLineupPositionPlayer>(
                    l => l.HasOne(x => x.Player).WithMany(x => x.MatchLineupPositionsPlayers).HasForeignKey(x => x.PlayerId).IsRequired().OnDelete(DeleteBehavior.NoAction),
                    r => r.HasOne(x => x.MatchLineupPosition).WithMany(x => x.MatchLineupPositionPlayers).HasForeignKey(x => x.MatchLineupPositionId).IsRequired());

            builder
                .HasOne(x => x.Position)
                .WithMany()
                .HasForeignKey(x => x.PositionId)
                .IsRequired();
        }
    }
}
