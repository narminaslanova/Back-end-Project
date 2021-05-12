using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Profession { get; set; }
        public string ImageURL { get; set; }
        public List<SpeakerEvent> SpeakerEvents { get; set; }
    }
}
