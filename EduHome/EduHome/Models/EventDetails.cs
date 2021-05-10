using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class EventDetails
    {
        public int Id { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Venue { get; set; }
        public string Speaker { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
