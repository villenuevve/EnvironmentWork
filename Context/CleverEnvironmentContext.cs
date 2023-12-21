using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EnvironmentWork.Context
{
    public partial class CleverEnvironmentContext : DbContext
    {
        public CleverEnvironmentContext()
            : base("name=CleverEnvironmentContext")
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<EventLog> EventLog { get; set; }
        public virtual DbSet<RadiationSensor> RadiationSensor { get; set; }
        public virtual DbSet<SoilSensor> SoilSensor { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Technician> Technician { get; set; }
        public virtual DbSet<WaterSensor> WaterSensor { get; set; }
        public virtual DbSet<WeatherSensor> WeatherSensor { get; set; }
        public virtual DbSet<Few_Info> Few_Info { get; set; }
        public virtual DbSet<More_Info> More_Info { get; set; }
        public virtual DbSet<Tech_Info> Tech_Info { get; set; }
        public virtual DbSet<User_Info> User_Info { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>()
                .Property(e => e.Admin_FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.Admin_LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.Admin_Email)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.Admin_Password)
                .IsUnicode(false);

            modelBuilder.Entity<EventLog>()
                .Property(e => e.EventName)
                .IsUnicode(false);

            modelBuilder.Entity<EventLog>()
                .HasMany(e => e.Administrator)
                .WithOptional(e => e.EventLog)
                .WillCascadeOnDelete();

            modelBuilder.Entity<RadiationSensor>()
                .Property(e => e.RadiationSensor_Location)
                .IsUnicode(false);

            modelBuilder.Entity<SoilSensor>()
                .Property(e => e.SoilSensor_Location)
                .IsUnicode(false);

            modelBuilder.Entity<Technician>()
                .Property(e => e.Tech_FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Technician>()
                .Property(e => e.Tech_LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Technician>()
                .Property(e => e.Tech_Email)
                .IsUnicode(false);

            modelBuilder.Entity<Technician>()
                .Property(e => e.Tech_Password)
                .IsUnicode(false);

            modelBuilder.Entity<Technician>()
                .HasMany(e => e.RadiationSensor)
                .WithOptional(e => e.Technician)
                .HasForeignKey(e => e.Technician_ID);

            modelBuilder.Entity<Technician>()
                .HasMany(e => e.SoilSensor)
                .WithOptional(e => e.Technician)
                .HasForeignKey(e => e.Technician_ID);

            modelBuilder.Entity<Technician>()
                .HasMany(e => e.WaterSensor)
                .WithOptional(e => e.Technician)
                .HasForeignKey(e => e.Technician_ID);

            modelBuilder.Entity<Technician>()
                .HasMany(e => e.WeatherSensor)
                .WithOptional(e => e.Technician)
                .HasForeignKey(e => e.Technician_ID);

            modelBuilder.Entity<WaterSensor>()
                .Property(e => e.WaterSensor_Location)
                .IsUnicode(false);

            modelBuilder.Entity<WeatherSensor>()
                .Property(e => e.WeatherSensor_Location)
                .IsUnicode(false);

            modelBuilder.Entity<Few_Info>()
                .Property(e => e.Event_name)
                .IsUnicode(false);

            modelBuilder.Entity<More_Info>()
                .Property(e => e.Event_name)
                .IsUnicode(false);

            modelBuilder.Entity<More_Info>()
                .Property(e => e.Technician_Last_name)
                .IsUnicode(false);

            modelBuilder.Entity<More_Info>()
                .Property(e => e.Administrator_Last_name)
                .IsUnicode(false);

            modelBuilder.Entity<Tech_Info>()
                .Property(e => e.Event_name)
                .IsUnicode(false);

            modelBuilder.Entity<Tech_Info>()
                .Property(e => e.Technician_Last_name)
                .IsUnicode(false);

            modelBuilder.Entity<User_Info>()
                .Property(e => e.Event_name)
                .IsUnicode(false);
        }
    }
}
