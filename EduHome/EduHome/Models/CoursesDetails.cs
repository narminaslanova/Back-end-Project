using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class CoursesDetails
    {
        public int Id { get; set; }
        public string MainDescription { get; set; }
        public string AboutCourse { get; set; }
        public string HowToApply { get; set; }
        public string Certification { get; set; }
        public int CourseId { get; set; }
        public Courses Course { get; set; }
        public CourseFeatures CourseFeatures { get; set; }
    }
}
