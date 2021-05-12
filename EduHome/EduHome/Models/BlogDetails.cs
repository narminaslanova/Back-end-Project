using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class BlogDetails
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
