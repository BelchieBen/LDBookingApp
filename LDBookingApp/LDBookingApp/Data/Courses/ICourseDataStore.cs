using LDBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LDBookingApp.Data.Courses
{
    public interface ICourseDataStore
    {
        event EventHandler CourseUpdated;
        Task<bool> AddCourseAsync(Course course);
        Task<bool> UpdateCourseAsync(Course course);
        Task<bool> DeleteCourseAsync(int id);
        Task<Course> GetCourseAsync(int id);
        Task<IEnumerable<Course>> GetCoursesAsync(bool forceRefresh = false);

    }
}
