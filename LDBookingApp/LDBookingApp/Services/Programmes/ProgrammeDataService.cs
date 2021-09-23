using LDBookingApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace LDBookingApp.Services.Programmes
{
    public class ProgrammeDataService : IProgrammeDataService
    {
        public event EventHandler ProgrammeUpdated;
        SQLiteAsyncConnection db;

        public ProgrammeDataService()
        {
            Task.Run(async () => await Initialize());
        }

        async Task Initialize()
        {
            if (db != null)
                return;
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "iLearnNew.db");
            db = new SQLiteAsyncConnection(databasePath);
            await db.CreateTableAsync<Programme>();
        }

        public async Task AddProgram(Programme p)
        {
            await db.InsertAsync(p);
            ProgrammeUpdated?.Invoke(this, new EventArgs());
        }

        public async Task EditProgramme(Programme p)
        {
            await Initialize();
            await db.InsertOrReplaceAsync(p);
            ProgrammeUpdated?.Invoke(this, new EventArgs());
        }

        public async Task<IList<Programme>> GetAllProgrammes()
        {
            var programmes = await db.Table<Programme>().OrderByDescending(o => o.DateAdded).ToListAsync();
            return programmes;
        }

        public async Task<IList<Programme>> GetTopProgrammes()
        {
            var programmes = await db.Table<Programme>().OrderByDescending(o => o.DateAdded).Take(3).ToListAsync();
            return programmes;
        }

        public async Task RemoveProgramme(Programme p)
        {
            await Initialize();
            await db.DeleteAsync(p);
            ProgrammeUpdated?.Invoke(this, new EventArgs());
        }
    }
}
