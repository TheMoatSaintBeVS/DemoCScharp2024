using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EfCoreOtherDemo
{
    public partial class Db2021WorldChampionShipContext : DbContext
    {
        public Db2021WorldChampionShipContext()
        {
        }

        public Db2021WorldChampionShipContext(DbContextOptions<Db2021WorldChampionShipContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Athete> Athetes { get; set; } = null!;
        public virtual DbSet<Result> Results { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<VTeamAthlete> VTeamAthletes { get; set; } = null!;
        public virtual DbSet<WorldChampionShip> WorldChampionShips { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.,9999\\SQL2019;Initial Catalog=Db2021WorldChampionShip;Persist Security Info=True;User ID=Db2021WorldChampionShipUser;Password=Db2021WorldChampionShipUser");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Athete>(entity =>
            {
                entity.ToTable("Athete");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Dob).HasColumnName("DOB");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Athetes)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEAM");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(e => new { e.AthleteId, e.WorldChampionShipId });

                entity.ToTable("Result");

                entity.HasOne(d => d.Athlete)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.AthleteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Athlete");

                entity.HasOne(d => d.WorldChampionShip)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.WorldChampionShipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorldChampionShip");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Country).IsUnicode(false);
            });

            modelBuilder.Entity<VTeamAthlete>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vTeamAthletes");

                entity.Property(e => e.Country)
                    .IsUnicode(false)
                    .HasColumnName("country");
            });

            modelBuilder.Entity<WorldChampionShip>(entity =>
            {
                entity.ToTable("WorldChampionShip");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.City).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
