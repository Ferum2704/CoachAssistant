﻿using CoachAssistant.Shared;
using Domain.Entities;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Coach> Coaches { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<Training> Trainings { get; set; } 

        public DbSet<TrainingRecord> TrainingRecords { get; set; }

        public DbSet<TrainingMark> TrainingMarks { get; set; }

        public DbSet<Criterion> Criteria { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<MatchTeam> MatchTeams { get; set; }

        public DbSet<MatchLineupPosition> MatchLineupPositions { get; set; }

        public DbSet<MatchPlayerAction> MatchPlayerActions { get; set; }

        public DbSet<PositionCriteria> PositionCriteria { get; set; }

        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<ActionType> ActionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new DomainUserConfiguration());
            modelBuilder.ApplyConfiguration(new ManagerConfiguration());
            modelBuilder.ApplyConfiguration(new CoachConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new ClubConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingRecordConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingMarkConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentConfiguration());
            modelBuilder.ApplyConfiguration(new MatchConfiguration());
            modelBuilder.ApplyConfiguration(new MatchLineupPositionConfiguration());
            modelBuilder.ApplyConfiguration(new MatchPlayerActionConfiguration());
            modelBuilder.ApplyConfiguration(new MatchTeamConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new CriterionConfiguration()); 
            modelBuilder.ApplyConfiguration(new ActionTypeConfiguration());

            modelBuilder.Entity<ApplicationUser>()
                .Navigation(x => x.DomainUser)
                .AutoInclude();

            // SeedIdentityData(modelBuilder);
        }

        private static void SeedIdentityData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationRole>()
                .HasData(
                    new ApplicationRole
                    {
                        Id = Guid.NewGuid(),
                        Name = ApplicationUserRole.Manager.ToString(),
                        ConcurrencyStamp = "1",
                        NormalizedName = ApplicationUserRole.Manager.ToString(),
                    },
                    new ApplicationRole
                    {
                        Id = Guid.NewGuid(),
                        Name = ApplicationUserRole.Coach.ToString(),
                        ConcurrencyStamp = "2",
                        NormalizedName = ApplicationUserRole.Coach.ToString(),
                    });
        }
    }
}
