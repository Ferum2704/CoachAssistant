using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.ToTable(nameof(Match));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Location).IsRequired();
            builder
                .Property(x => x.MatchType)
                .HasConversion<string>()
                .IsRequired();

            builder
                .HasMany(x => x.PlayerActions)
                .WithOne(x => x.Match)
                .HasForeignKey(x => x.MatchId);

            builder
                .HasMany(x => x.Teams)
                .WithMany(x => x.Matches)
                .UsingEntity<MatchTeam>(
                    l => l.HasOne(x => x.Team).WithMany(x => x.MatchTeams).HasForeignKey(x => x.TeamId).IsRequired(),
                    r => r.HasOne(x => x.Match).WithMany(x => x.MatchTeams).HasForeignKey(x => x.MatchId).IsRequired());
        }
    }
}
