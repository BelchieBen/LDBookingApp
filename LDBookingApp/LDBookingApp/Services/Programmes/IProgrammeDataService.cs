using LDBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LDBookingApp.Services.Programmes
{
    public interface IProgrammeDataService
    {
        event EventHandler ProgrammeUpdated;
        Task<IList<Programme>> GetAllProgrammes();
        Task<IList<Programme>> GetTopProgrammes();
        Task AddProgram(Programme p);
        Task EditProgramme(Programme p);
        Task RemoveProgramme(Programme p);
    }
}
