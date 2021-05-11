using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class CourseFeatures
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public double Duration { get; set; }
        public double ClassDuration { get; set; }
        public string SkillLevel { get; set; }
        public string Language { get; set; }
        public int StudentCount { get; set; }
        public string Assesment { get; set; }
        public double Fee { get; set; }
        [ForeignKey("CoursesDetails")]
        public int CourseDetailsId { get; set; }
        public CoursesDetails CoursesDetails { get; set; }
    }
}
