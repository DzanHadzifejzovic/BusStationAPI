using BusStation_API.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Config;
using System.Reflection;

namespace BusStation_API.Infrastructure.Persistence
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
            modelBuilder.Entity<BusLine>()
            .HasOne(bl => bl.Bus)
            .WithMany(k => k.BusLines)
            .HasForeignKey(bl => bl.BusId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BusLineUser>()
            .Property(blu => blu.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<BusLineUser>()
            .HasKey(bl => new { bl.BusLineId, bl.UserId });

            modelBuilder.Entity<BusLineUser>()
            .HasOne(bl => bl.BusLine)
            .WithMany(k => k.BusLineUsers)
            .HasForeignKey(bl => bl.BusLineId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BusLineUser>()
            .HasOne(bl => bl.User)
            .WithMany(k => k.BusLineUsers)
            .HasForeignKey(bl => bl.UserId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new IdentityUserConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

        }
    }
}
