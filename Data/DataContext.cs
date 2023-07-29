using Data.Configurations;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataContext:IdentityDbContext<BaseUser> 
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
        }

        public DbSet<Bus> Buses {get;set;}
        public DbSet<BusLine> BusLines  { get; set; }
        public DbSet<BusLineUser> BusLinesUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<BusLine>()
            .HasOne(bl => bl.Bus)
            .WithMany(k => k.BusLines)
            .HasForeignKey(bl => bl.BusId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BusLineUser>()
            .HasOne(bl => bl.User)
            .WithMany(k => k.BusLineUsers)
            .HasForeignKey(bl => bl.UserId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BusLineUser>()
            .HasOne(bl => bl.BusLine)
            .WithMany(k => k.BusLineUsers)
            .HasForeignKey(bl => bl.BusLineId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new IdentityUserConfiguration());
            
        }
    }
}
