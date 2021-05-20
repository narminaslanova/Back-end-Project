using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Testimonials
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImageURL { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Position { get; set; }
        public bool IsDeleted { get; set; }

    }
}
