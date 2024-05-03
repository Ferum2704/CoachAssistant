using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class CoachConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.ToTable(nameof(Coach));

            builder
                .HasOne(x => x.Team)
                .WithOne(x => x.Coach)
                .HasForeignKey<Team>(x => x.CoachId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
