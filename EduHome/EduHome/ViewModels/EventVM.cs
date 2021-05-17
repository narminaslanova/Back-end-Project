using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class EventVM
    {
        public Event Event { get; set; }
        public EventDetails EventDetails { get; set; }
        public List<int> Speaker { get; set; }
    }
}
