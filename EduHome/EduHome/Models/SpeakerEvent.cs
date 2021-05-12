using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class SpeakerEvent
    {
        public int Id { get; set; }
        public int SpeakerId { get; set; }
        public  Speaker Speaker { get; set; }
        public int EventId { get; set; }
        public  Event Event { get; set; }
    }
}
