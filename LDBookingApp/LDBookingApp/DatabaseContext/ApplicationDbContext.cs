using LDBookingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;

namespace LDBookingApp.DatabaseContext
{
    public class ApplicationDbContext : DbContext //, ICourseDataStore
    {
        private string _databasePath;
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Course> Courses { get; set; }

        public ApplicationDbContext(string databasePath)
        {
            _databasePath = databasePath;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Course>()
                .HasOne<Programme>();

            modelBuilder.Entity<Programme>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Programme>()
                .HasMany<Course>();

            #if DEBUG
            // Adding some startup data
            modelBuilder.Entity<Programme>()
                .HasData(
                    new Programme { Id = 1, Name = "Programming", Description = "Learn how to code!", DateAdded = DateTime.Now },
                    new Programme { Id = 2, Name = "Communication Skills", Description = "Speak more effectivly", DateAdded = DateTime.Now }
                );

            modelBuilder.Entity<Course>()
                .HasData(
                    new Course { Id = 1, Name = "Learn C#", Description = "The best C# Course!", CourseStart = DateTime.Today, CourseEnd = DateTime.Today, DateAdded = DateTime.Now, MaxParticipents = 6, ProgrammeName = Programmes.FirstOrDefault(x => x.Id == 1) },
                    new Course { Id = 2, Name = "Learn Python", Description = "The python course for noobs", CourseStart = DateTime.Today, CourseEnd = DateTime.Today, DateAdded = DateTime.Now, MaxParticipents = 10, ProgrammeName = Programmes.FirstOrDefault(x => x.Id == 1) },
                    new Course { Id = 3, Name = "Build Assertiveness", Description = "Be more assertive", CourseStart = DateTime.Today, CourseEnd = DateTime.Today, DateAdded = DateTime.Now, MaxParticipents = 5, ProgrammeName = Programmes.FirstOrDefault(x => x.Id == 2) }
                );
            #endif
        }
    }
}
