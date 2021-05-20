using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class CourseFeatures
    {
        public int Id { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }
        [Required]
        public double Duration { get; set; }
        [Required]
        public double ClassDuration { get; set; }
        [Required]
        public string SkillLevel { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public int StudentCount { get; set; }
        [Required]
        public string Assesment { get; set; }
        [Required]
        public double Fee { get; set; }
        [ForeignKey("CoursesDetails")]
        public int CourseDetailsId { get; set; }
        public CoursesDetails CoursesDetails { get; set; }
    }
}
