using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class CoursesVM
    {
        public Courses Course { get; set; }
        public CoursesDetails CoursesDetails { get; set; }
        public CourseFeatures CourseFeatures { get; set; }

    }
}
