using LDBookingApp.Data.Courses;
using LDBookingApp.Models;
using LDBookingApp.Services.Navigation;
using LDBookingApp.Services.Programmes;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LDBookingApp.ViewModels.Courses
{
    public class AddCourseViewModel : BaseViewModel
    {
        private ICourseDataStore _courseDataStore;
        private IProgrammeDataService _programmeDataService;
        private INavigationService _navigationService;
        private Course _selectedCourse;
        private int _id;
        private string _name;
        private string _description;
        private DateTime _courseStart;
        private DateTime _courseEnd;
        private int _maxParticipants;
        private Programme _programme;
        public AsyncCommand AddCourseCommand { get; }

        #region Course Properties

        public int id
        {
            get => _id;
            set
            {
                _id = value;
            }
        }
        public string name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }
        public string description
        {
            get => _description;
            set
            {
                _description = value;
            }
        }
        public DateTime courseStart
        {
            get => _courseStart;
            set
            {
                _courseStart = value;
                OnPropertyChanged("CourseStart");
            }
        }
        public DateTime courseEnd
        {
            get => _courseEnd;
            set
            {
                _courseEnd = value;
                OnPropertyChanged("CourseEnd");
            }
        }
        public int maxParticipents
        {
            get => _maxParticipants;
            set
            {
                _maxParticipants = value;
            }
        }
        public Programme programme
        {
            get => _programme;
            set
            {
                _programme = value;
            }
        }
        public List<Programme> ProgrammeList { get; set; }
        public Course SelectedCourse
        {
            get => _selectedCourse;
            set
            {
                _selectedCourse = value;
                OnPropertyChanged("SelectedCourse");
            }
        }

        #endregion
        public AddCourseViewModel(INavigationService navigationService, IProgrammeDataService programmeDataService, ICourseDataStore courseDataStore)
        {
            AddCourseCommand = new AsyncCommand(() => AddCourseCommandExecuted());

            SelectedCourse = new Course();
            _navigationService = navigationService;
            _programmeDataService = programmeDataService;
            _courseDataStore = courseDataStore;

            Task.Run(async () => await GetProgrammes());
        }

        public async Task AddCourseCommandExecuted()
        {
            var c = new Course()
            {
                Id = id,
                Name = name,
                Description = description,
                CourseStart = courseStart,
                CourseEnd = courseEnd,
                MaxParticipents = maxParticipents,
                DateAdded = DateTime.Now,
            };
            await _courseDataStore.AddCourseAsync(c);
            await _navigationService.RemovePopUp();
        }

        private async Task GetProgrammes()
        {
            ProgrammeList = (List<Programme>)await _programmeDataService.GetAllProgrammes();
        }
    }
}
