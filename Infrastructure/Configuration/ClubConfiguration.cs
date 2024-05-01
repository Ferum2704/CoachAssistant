using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ClubConfiguration : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> builder)
        {
            builder.ToTable(nameof(Club));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.Region).IsRequired();
            
            builder
                .HasOne(x => x.Team)
                .WithOne(x => x.Club)
                .HasForeignKey<Team>(x => x.ClubId)
                .IsRequired();
        }
    }
}
