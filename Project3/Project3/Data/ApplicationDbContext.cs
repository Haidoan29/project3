using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project3.Models;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Transaction = Project3.Models.Transaction;

namespace Project3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


            //this.Data();
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Cancellation> Cancellations { get; set; }
        public virtual DbSet<CancellationFeeRule> CancellationFeeRules { get; set; }
        public virtual DbSet<DailyCashTransaction> DailyCashTransactions { get; set; }
        public virtual DbSet<DayMaster> DayMasters { get; set; }
        public virtual DbSet<FareRule> FareRules { get; set; }
        public virtual DbSet<ReservationSuperFastFee> ReservationSuperFastFees { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<Routers> Routers { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Cấu hình khóa ngoại cho Routers
        //    modelBuilder.Entity<Routers>()
        //        .HasOne(r => r.StartStation)
        //        .WithMany(s => s.StartRoutes)
        //        .HasForeignKey(r => r.StartStationID)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    modelBuilder.Entity<Routers>()
        //        .HasOne(r => r.EndStations)
        //        .WithMany(s => s.EndRoutes)
        //        .HasForeignKey(r => r.EndStationID)
        //        .OnDelete(DeleteBehavior.Restrict);
        //    // Cấu hình khóa ngoại cho Transactions
        //    modelBuilder.Entity<Transaction>()
        //        .HasOne(t => t.FromStation)
        //        .WithMany(s => s.FromTransaction)
        //        .HasForeignKey(t => t.FromStationID)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    modelBuilder.Entity<Transaction>()
        //        .HasOne(t => t.ToStation)
        //        .WithMany(s => s.ToTransaction)
        //        .HasForeignKey(t => t.ToStationID)
        //        .OnDelete(DeleteBehavior.Restrict);
        //    // Cấu hình khóa ngoại cho TrainSchedule
        //    modelBuilder.Entity<TrainSchedule>()
        //        .HasOne(t => t.StartStation)
        //        .WithMany(s => s.StartTrainSchedules)
        //        .HasForeignKey(t => t.StartStationID)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    modelBuilder.Entity<TrainSchedule>()
        //        .HasOne(t => t.EndStation)
        //        .WithMany(s => s.EndTrainSchedules)
        //        .HasForeignKey(t => t.EndStationID)
        //        .OnDelete(DeleteBehavior.Restrict);




        //    base.OnModelCreating(modelBuilder);
        //}



        //public virtual DbSet<Train> Trains { get; set; }
        //public virtual DbSet<TrainSchedule> TrainSchedules { get; set; }
        //public virtual DbSet<Transaction> Transactions { get; set; }
        //private async void Data()
        //{
        //    if (this.Class.Count() <= 0)
        //    {
        //        var c1 = new Class() { ClassName = "C2209G" };
        //        var c2 = new Class() { ClassName = "C2209G1" };
        //        var c3 = new Class() { ClassName = "C2209G2" };
        //        var c4 = new Class() { ClassName = "A11111A" };
        //        var c5 = new Class() { ClassName = "C2209G4" };
        //        var c6 = new Class() { ClassName = "C2209D" };


        //        this.Class.Add(c1);
        //        this.Class.Add(c2);
        //        this.Class.Add(c3);
        //        this.Class.Add(c4);
        //        this.Class.Add(c5);
        //        this.Class.Add(c6);

        //        this.SaveChanges();
        //    }
        //}
    }
}
