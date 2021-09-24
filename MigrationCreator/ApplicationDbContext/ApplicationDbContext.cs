using LDBookingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MigrationCreator.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Course> Courses { get; set; }
        private const string DatabaseName = "iLearnNewDb.db";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DatabaseName}");
        }
    }
}
