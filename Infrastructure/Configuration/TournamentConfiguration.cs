using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.ToTable(nameof(Tournament));

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name);

            builder
                .HasMany(x => x.Matches)
                .WithOne(x => x.Tournament)
                .HasForeignKey(x => x.TournamentId)
                .IsRequired();

            builder
                .HasMany(x => x.Teams)
                .WithMany(x => x.Tournaments)
                .UsingEntity<TournamentTeam>(
                    l => l.HasOne(x => x.Team).WithMany(x => x.TournamentTeams).HasForeignKey(x => x.TeamId).IsRequired(),
                    r => r.HasOne(x => x.Tournament).WithMany(x => x.TournamentTeams).HasForeignKey(x => x.TournamentId).IsRequired());
        }
    }
}
