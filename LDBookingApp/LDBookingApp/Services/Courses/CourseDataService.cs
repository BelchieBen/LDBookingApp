using LDBookingApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace LDBookingApp.Services.Courses
{
    public class CourseDataService : ICourseDataService
    {
        public event EventHandler CourseUpdated;
        SQLiteAsyncConnection db;

        public CourseDataService()
        {
            Task.Run(async () => await Initialize());
        }

        async Task Initialize()
        {
            if (db != null)
                return;
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "iLearn.db");
            db = new SQLiteAsyncConnection(databasePath);
            await db.CreateTableAsync<Course>();
        }
        public async Task<IList<Course>> GetTopCourses()
        {
            var courses = await db.Table<Course>().OrderByDescending(o => o.DateAdded).Take(3).ToListAsync();
            return courses;
        }

        public async Task<IList<Course>> GetAllCourses()
        {
            var courses = await db.Table<Course>().OrderByDescending(o => o.DateAdded).ToListAsync();
            return courses;
        }

        public async Task AddCourse(Course c)
        {
            //var dbNew = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "iLearn.db"));
            await db.InsertAsync(c);
            CourseUpdated?.Invoke(this, new EventArgs());
        }

        public async Task UpdateCourse(Course c)
        {
            await Initialize();
            await db.InsertOrReplaceAsync(c);
            CourseUpdated?.Invoke(this, new EventArgs());

        }

        public async Task DeleteCourse(Course c)
        {
            await Initialize();
            await db.DeleteAsync(c);
            CourseUpdated?.Invoke(this, new EventArgs());
        }
    }
}
