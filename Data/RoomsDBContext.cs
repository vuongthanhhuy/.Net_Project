using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{
    public class RoomsDBContext : DbContext
    {
        public RoomsDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Rooms> Rooms { get; set; }
    }
}
