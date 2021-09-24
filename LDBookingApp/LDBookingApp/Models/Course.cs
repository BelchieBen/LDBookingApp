using System;
using System.ComponentModel.DataAnnotations.Schema;
using ForeignKeyAttribute = SQLiteNetExtensions.Attributes.ForeignKeyAttribute;

namespace LDBookingApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CourseStart { get; set; }
        public DateTime CourseEnd { get; set; }
        public int MaxParticipents { get; set; }
        public int ProgrammeId { get; set; }
        public Programme ProgrammeName { get; set; }
        public DateTime DateAdded { get; set; }
    }

    public enum CourseProgramme
    {
        Programming,
        Assertive_Communication,
    }
}
