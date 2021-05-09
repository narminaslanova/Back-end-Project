using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string City { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }

    }
}
