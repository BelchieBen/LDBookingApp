using LDBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LDBookingApp.Data.Programmes
{
    public interface IProgrammeDataStore
    {
        event EventHandler ProgrammeUpdated;
        Task<bool> AddProgrammeAsync(Programme programme);
        Task<bool> UpdateProgrammeAsync(Programme programme);
        Task<bool> DeleteProgrammeAsync(int id);
        Task<Programme> GetProgrammeAsync(int id);
        Task<IEnumerable<Programme>> GetProgrammesAsync(bool forceRefresh = false);
    }
}
