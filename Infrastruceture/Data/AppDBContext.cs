using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<ElectricVehicle> ElectricVehicles { get; set; }

        public DbSet<ElectricVehicleType> ElectricVehicleTypes { get; set; }

        public DbSet<RepairHistory> RepairHistories { get; set; }

        public DbSet<ReplacementPart> ReplacementParts { get; set; }

        public DbSet<RepairHistoryPart> RepairHistoryParts { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<AuditLog> AuditLogs { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //CREATE SUPER ADMIN 
            modelBuilder.Entity<User>().HasData(new
            {
                UserId = Guid.Parse("A1B2C3D4-E5F6-4A5B-8C9D-0E1F2A3B4C5D"),
                UserName = "Hưng",
                Email = "hungvd18@gmail.com",
                PhoneNumber = "0826078586",
                Role = "SuperAdmin", // Quyền cao nhất
                IdentityCard = "012345667899",
                IsActive = true,
                Password = "$2a$11$JdYSVNQ6sh41E5eHTaC4Vu6M6dSiusX2NKc2/W7FN.oFkzjyLQnnu"// Mật khẩu gốc
            });

            //MAPPING REPAIRHISTORY TO ELECTRIC VEHICLE
            modelBuilder.Entity<RepairHistory>().HasOne(r => r.ElectricVehicle).WithMany(v => v.RepairHistories).HasForeignKey(r => r.ElectricVehicleId);

            //MAPPING REPAIRHISTORYPART TO REPAIRHISTORY
            modelBuilder.Entity<RepairHistoryPart>().HasOne(rp => rp.RepairHistory).WithMany(r => r.Parts).HasForeignKey(rp => rp.RepairId);

            //MAPPING REPAIRHISTORYPART TO REPLACEMENTPART
            modelBuilder.Entity<RepairHistoryPart>().HasOne(rp => rp.ReplacementPart).WithMany(p => p.RepairHistoryParts).HasForeignKey(rp => rp.PartId);

            //one to one payment
            modelBuilder.Entity<Payment>().HasOne(p => p.RepairHistory).WithOne(r => r.Payment).HasForeignKey<Payment>(p => p.RepairId);
        }
    }
}
