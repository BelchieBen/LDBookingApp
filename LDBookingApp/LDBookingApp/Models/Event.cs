using System;
using System.Collections.Generic;
using System.Text;

namespace LDBookingApp.Models
{
    public class Event
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Host { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public List<Course> Course { get; set; }
    }
}
