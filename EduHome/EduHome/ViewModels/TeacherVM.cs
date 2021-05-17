using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class TeacherVM
    {
        public Teacher Teacher { get; set; }
        public TeacherDetails TeacherDetails { get; set; }
        public Skills Skills { get; set; }
        public List<int> SocialMedias { get; set; }

    }
}
