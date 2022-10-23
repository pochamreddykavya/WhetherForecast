using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ResfulCrudOperations.Models
{
    public partial class WhetherForecastDBContext : DbContext
    {
        public WhetherForecastDBContext()
        {
        }

        public WhetherForecastDBContext(DbContextOptions<WhetherForecastDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<WhetherForecast> WhetherForecast { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=WhetherForecastDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityId).ValueGeneratedNever();

                entity.Property(e => e.CityName).HasMaxLength(50);

                entity.Property(e => e.DateEstablished).HasColumnType("datetime");

                entity.Property(e => e.EstimatedPopulation).HasMaxLength(50);

                entity.Property(e => e.State)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CityId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CountryId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ThreeDigitCountryCode)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TwoDigitCountryCode)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<WhetherForecast>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Uv).HasColumnName("UV");

                entity.Property(e => e.WhetherDescription).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
