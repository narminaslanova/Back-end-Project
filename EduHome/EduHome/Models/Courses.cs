using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Courses
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImageURL { get; set; }
        [NotMapped, Required]
        public IFormFile Photo { get; set; }
        public bool IsDeleted { get; set; }
        public CoursesDetails CoursesDetails { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
