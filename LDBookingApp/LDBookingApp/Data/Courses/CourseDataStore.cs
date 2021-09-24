using LDBookingApp.DatabaseContext;
using LDBookingApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDBookingApp.Data.Courses
{
    public class CourseDataStore : ApplicationDbContext, ICourseDataStore
    {
        public event EventHandler CourseUpdated;
        public CourseDataStore(string databasePath) : base(databasePath)
        {

        }
        public async Task<Course> GetCourseAsync(int id)
        {
            var course = await Courses.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            return course;
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync(bool forceRefresh = false)
        {
            var allCourses = await Courses.Include(x => x.ProgrammeName).ToListAsync().ConfigureAwait(false);
            return allCourses;
        }

        public async Task<bool> AddCourseAsync(Course course)
        {
            await Courses.AddAsync(course).ConfigureAwait(false);
            await SaveChangesAsync().ConfigureAwait(false);
            CourseUpdated?.Invoke(this, new EventArgs());
            return true;
        }

        public async Task<bool> UpdateCourseAsync(Course course)
        {
            Courses.Update(course);
            await SaveChangesAsync().ConfigureAwait(false);
            CourseUpdated?.Invoke(this, new EventArgs());
            return true;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var courseToDelete = Courses.FirstOrDefault(x => x.Id == id);
            if (courseToDelete != null)
            {
                Courses.Remove(courseToDelete);
                await SaveChangesAsync().ConfigureAwait(false);
            }
            CourseUpdated?.Invoke(this, new EventArgs());
            return true;
        }
    }
}
