using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{
    public class SystemDBContext : DbContext
    {
        public SystemDBContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Rooms>()
                        .HasOne(e => e.RoomFacilities)
                        .WithOne(e => e.Rooms)
                        .HasForeignKey<RoomFacilities>(e => e.RoomId)
                        .IsRequired();
            modelBuilder.Entity<RoomFacilities>()
                        .HasOne(e => e.Rooms)
                        .WithOne(e => e.RoomFacilities)
                        .HasForeignKey<RoomFacilities>(e => e.RoomId)
                        .IsRequired();
        }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<RoomFacilities> RoomsFacilities { get; set; }
        public DbSet<RestaurantMenus> RestaurantMenus { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Orderings> Orderings { get; set; }
        public DbSet<RoomReviews> RoomReviews { get; set; }
        public DbSet<History> History { get; set; }
    }
}
