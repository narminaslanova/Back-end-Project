using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Profession { get; set; }
        public string ImageURL { get; set; }
        public bool IsDeleted { get; set; }
        public TeacherDetails TeacherDetails { get; set; }
        public virtual ICollection<SocialMedia> SocialMedias { get; set; }

        
        

    }
}
