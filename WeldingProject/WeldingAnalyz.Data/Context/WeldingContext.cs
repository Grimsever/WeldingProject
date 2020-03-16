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
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().HasKey(x => x.WorkerID);
            modelBuilder.Entity<Foreman>().HasKey(x => x.ForemanId);
            modelBuilder.Entity<Task>().HasKey(x => x.TaskId);
            modelBuilder.Entity<TechnologicalMap>().HasKey(x => x.TechnologicalMapId);
            modelBuilder.Entity<Machine>().HasKey(x => x.MachineId);

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
