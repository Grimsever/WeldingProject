using Microsoft.EntityFrameworkCore;
using WeldingAnalyz.DAL.Models;

namespace WeldingAnalyz.Data.Context
{
    public class WeldingContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Foreman> Foremans { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TechnologicalMap> TechnologicalMaps { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Amperage> Amperages { get; set; }
        public DbSet<Voltage> Voltages { get; set; }
        public DbSet<MachineData> MachineDatas { get; set; }


        public WeldingContext(DbContextOptions<WeldingContext> option) : base(option)
        {
            Database.Migrate();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().HasKey(x => x.Id);
            modelBuilder.Entity<Foreman>().HasKey(x => x.Id);
            modelBuilder.Entity<Task>().HasKey(x => x.Id);
            modelBuilder.Entity<TechnologicalMap>().HasKey(x => x.Id);
            modelBuilder.Entity<Machine>().HasKey(x => x.Id);

            modelBuilder.Entity<Voltage>()
                .HasOne(x => x.MachineData)
                .WithMany(x => x.Voltages)
                .HasForeignKey(x => x.MachineDataId);


            modelBuilder.Entity<Amperage>()
                .HasOne(x => x.MachineData)
                .WithMany(x => x.Amperages)
                .HasForeignKey(x => x.MachineDataId);


            modelBuilder.Entity<MachineData>()
                .HasOne(x => x.Machine)
                .WithOne(x => x.MachineData)
                .HasForeignKey<Machine>(x => x.MachineDataId);

            modelBuilder.Entity<Task>()
                .HasOne(x => x.Machine)
                .WithOne(x => x.Task)
                .HasForeignKey<Machine>(x => x.TaskId);

            modelBuilder.Entity<Task>()
                .HasOne(x => x.TechnologicalMap)
                .WithOne(x => x.Task)
                .HasForeignKey<TechnologicalMap>(x => x.TaskId);

            modelBuilder.Entity<Worker>()
                .HasOne(x => x.Task)
                .WithOne(x => x.Worker)
                .HasForeignKey<Task>(x => x.WorkerId);

            modelBuilder.Entity<Worker>()
                .HasOne(x => x.Foreman)
                .WithMany(x => x.Workers)
                .HasForeignKey(x => x.ForemanId);
        }
    }
}
