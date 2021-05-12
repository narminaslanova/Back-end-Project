using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public string Author { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public BlogDetails BlogDetails { get; set; }
    }
}
