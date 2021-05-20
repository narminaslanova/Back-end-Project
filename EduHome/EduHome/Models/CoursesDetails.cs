using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class CoursesDetails
    {
        public int Id { get; set; }
        [Required]
        public string MainDescription { get; set; }
        [Required]
        public string AboutCourse { get; set; }
        [Required]
        public string HowToApply { get; set; }
        [Required]
        public string Certification { get; set; }
        public int CourseId { get; set; }
        public Courses Course { get; set; }
        public CourseFeatures CourseFeatures { get; set; }
    }
}
