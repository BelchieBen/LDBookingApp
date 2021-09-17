using LDBookingApp.Models;
using LDBookingApp.Services.Courses;
using LDBookingApp.Services.Navigation;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LDBookingApp.ViewModels.Courses
{
    public class AddCourseViewModel : BaseViewModel
    {
        private ICourseDataService _courseDataService;
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
        public List<Programme> programss { get; set; }
        public Course SelectedCourse
        {
            get => _selectedCourse;
            set
            {
                _selectedCourse = value;
                OnPropertyChanged("SelectedCourse");
            }
        }
        public AddCourseViewModel(ICourseDataService courseDataService, INavigationService navigationService)
        {
            AddCourseCommand = new AsyncCommand(() => AddCourseCommandExecuted());
            programss = new List<Programme>()
            {
                new Programme()
                {
                    Id = new Guid().ToString(),
                    Name = "First Programme",
                    Description = "This is the description"
                },
                new Programme()
                {
                    Id = new Guid().ToString(),
                    Name = "Second programme",
                    Description = "Second Description"
                }
            };

            SelectedCourse = new Course();
            _courseDataService = courseDataService;
            _navigationService = navigationService;
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
                ProgrammeName = programme.Name,
                DateAdded = DateTime.Now,
            };
            await _courseDataService.AddCourse(c);
            await _navigationService.RemovePopUp();
        }
    }
}
