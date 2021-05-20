using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Profession { get; set; }
        [Required]
        public string ImageURL { get; set; }
        public List<SpeakerEvent> SpeakerEvents { get; set; }
    }
}
