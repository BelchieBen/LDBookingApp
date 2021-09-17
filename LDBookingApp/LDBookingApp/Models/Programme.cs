using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LDBookingApp.Models
{
    public class Programme
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [OneToMany]
        public List<Course> Courses { get; set; }
    }
}
