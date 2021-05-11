using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class SocialMedia
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Link { get; set; }
        public int TeacherId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Teacher Teacher { get; set; }
       
    }
}
