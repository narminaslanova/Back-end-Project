using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class TeacherDetails
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public int Experience { get; set; }
        [Required]
        public string Hobbies { get; set; }
        [Required]
        public string Faculty { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public Skills Skills { get; set; }
    }
}
