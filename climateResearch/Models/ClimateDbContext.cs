namespace climateResearch.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using climateResearch;
    using climateResearch.Models.Entities;

    public partial class ClimateDbContext : IdentityDbContext<User>
    {
        public ClimateDbContext()
            : base("name=climateDB")
        {
        }
        public static ClimateDbContext Create()
        {
            return new ClimateDbContext();
        }

        public virtual DbSet<MeasuringInstrument> MeasuringInstruments { get; set; }
        public virtual DbSet<ObservationPoint> ObservationPoints { get; set; }
        public virtual DbSet<PhysicalQuantity> PhysicalQuantities { get; set; }
        public virtual DbSet<Sensor> Sensors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeasuringInstrument>()
                .HasMany(e => e.Sensors)
                .WithOptional(e => e.MeasuringInstrument)
                .HasForeignKey(e => e.MeasuringInstrumentId);

            modelBuilder.Entity<ObservationPoint>()
                .Property(e => e.Latitude)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ObservationPoint>()
                .Property(e => e.Longtitude)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ObservationPoint>()
                .HasMany(e => e.MeasuringInstruments)
                .WithOptional(e => e.ObservationPoint)
                .HasForeignKey(e => e.ObservationPointId);

            modelBuilder.Entity<PhysicalQuantity>()
                .HasMany(e => e.Sensors)
                .WithOptional(e => e.PhysicalQuantity)
                .HasForeignKey(e => e.PhysicalQuantityId);

            modelBuilder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
