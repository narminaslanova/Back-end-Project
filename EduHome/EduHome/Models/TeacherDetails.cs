using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class TeacherDetails
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Degree { get; set; }
        public int Experience { get; set; }
        public string Hobbies { get; set; }
        public string Faculty { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public Skills Skills { get; set; }
    }
}
