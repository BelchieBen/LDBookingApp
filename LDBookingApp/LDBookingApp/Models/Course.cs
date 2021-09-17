﻿using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace LDBookingApp.Models
{
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CourseStart { get; set; }
        public DateTime CourseEnd { get; set; }
        public int MaxParticipents { get; set; }
        [ForeignKey(typeof(Programme)), Indexed]
        public string ProgrammeName { get; set; }
        public DateTime DateAdded { get; set; }
    }
}