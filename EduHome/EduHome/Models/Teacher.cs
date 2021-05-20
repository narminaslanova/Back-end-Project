using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Profession { get; set; }
        [Required]
        public string ImageURL { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public bool IsDeleted { get; set; }
        public TeacherDetails TeacherDetails { get; set; }
        public virtual ICollection<SocialMedia> SocialMedias { get; set; }

        
        

    }
}
