using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Courses> Courses { get; set; }
        public List<NoticeBoard> NoticeBoards { get; set; }
        public List<InfoCard> InfoCards { get; set; }
        public AboutInfo AboutInfo { get; set; }
        public List<Event> Events { get; set; }
        public List<Testimonials> Testimonials { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
