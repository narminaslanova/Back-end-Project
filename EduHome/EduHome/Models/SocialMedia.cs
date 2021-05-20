using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class SocialMedia
    {
        public int Id { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public string Link { get; set; }
        public int TeacherId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Teacher Teacher { get; set; }
       
    }
}
