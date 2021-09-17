using LDBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LDBookingApp.Services.Courses
{
    public interface ICourseDataService
    {
        event EventHandler CourseUpdated;
        Task<IList<Course>> GetTopCourses();
        Task AddCourse(Course c);
        Task UpdateCourse(Course c);
        Task DeleteCourse(Course c);
        Task<IList<Course>>GetAllCourses();
    }
}
