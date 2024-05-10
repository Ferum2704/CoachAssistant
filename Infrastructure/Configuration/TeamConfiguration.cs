using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable(nameof(Team));

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired();

            builder
                .Property(x => x.VerificationState)
                .HasConversion<string>()
                .IsRequired();

            builder
                .HasMany(x => x.Players)
                .WithOne(x => x.Team)
                .HasForeignKey(x => x.TeamId)
                .IsRequired();

            builder
                .HasMany(x => x.Trainings)
                .WithOne(x => x.Team)
                .HasForeignKey(x => x.TeamId)
                .IsRequired();
        }
    }
}
