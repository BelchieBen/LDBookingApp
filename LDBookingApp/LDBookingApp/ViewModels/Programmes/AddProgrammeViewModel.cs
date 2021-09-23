﻿using LDBookingApp.Models;
using LDBookingApp.Services.Navigation;
using LDBookingApp.Services.Programmes;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LDBookingApp.ViewModels.Programmes
{
    public class AddProgrammeViewModel : BaseViewModel
    {
        private IProgrammeDataService _programmeDataService;
        private INavigationService _navigationService;

        private Programme _selectedProgramme;
        private int _id;
        private string _name;
        private string _description;

        public AsyncCommand AddProgrammeCommand { get; }

        #region Programme Properties
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

        public Programme SelectedProgramme
        {
            get => _selectedProgramme;
            set
            {
                _selectedProgramme = value;
                OnPropertyChanged("SelectedProgramme");
            }
        }

        #endregion

        public AddProgrammeViewModel(IProgrammeDataService programmeDataService, INavigationService navigationService)
        {
            AddProgrammeCommand = new AsyncCommand(() => AddProgrammeCommandExecuted());
            _programmeDataService = programmeDataService;
            _navigationService = navigationService;
        }

        public async Task AddProgrammeCommandExecuted()
        {
            var p = new Programme()
            {
                Id = id,
                Name = name,
                Description = description,
                Courses = new List<Course>(),
                DateAdded = DateTime.Now,
            };
            await _programmeDataService.AddProgram(p);
            await _navigationService.RemovePopUp();
        }
    }
}
