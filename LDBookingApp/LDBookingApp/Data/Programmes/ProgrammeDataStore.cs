using LDBookingApp.DatabaseContext;
using LDBookingApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDBookingApp.Data.Programmes
{
    public class ProgrammeDataStore : ApplicationDbContext, IProgrammeDataStore
    {
        public event EventHandler ProgrammeUpdated;

        public ProgrammeDataStore(string databasePath) : base(databasePath)
        {

        }

        public async Task<bool> AddProgrammeAsync(Programme programme)
        {
            await Programmes.AddAsync(programme).ConfigureAwait(false);
            await SaveChangesAsync().ConfigureAwait(false);
            ProgrammeUpdated?.Invoke(this, new EventArgs());
            return true;
        }

        public async Task<bool> DeleteProgrammeAsync(int id)
        {
            var programmeToDelete = Programmes.FirstOrDefault(x => x.Id == id);
            if (programmeToDelete != null)
            {
                Programmes.Remove(programmeToDelete);
                await SaveChangesAsync().ConfigureAwait(false);
            }
            ProgrammeUpdated?.Invoke(this, new EventArgs());
            return true;
        }

        public async Task<IEnumerable<Programme>> GetProgrammesAsync(bool forceRefresh = false)
        {
            var allProgrammes = await Programmes.ToListAsync().ConfigureAwait(false);
            return allProgrammes;
        }

        public async Task<Programme> GetProgrammeAsync(int id)
        {
            var programme = await Programmes.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            return programme;
        }

        public async Task<bool> UpdateProgrammeAsync(Programme programme)
        {
            Programmes.Update(programme);
            await SaveChangesAsync().ConfigureAwait(false);
            ProgrammeUpdated?.Invoke(this, new EventArgs());
            return true;
        }
    }
}
