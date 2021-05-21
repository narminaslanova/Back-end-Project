using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Subscribers
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public List<SubscribeEvent> SubscribeEvents { get; set; }
    }
}
