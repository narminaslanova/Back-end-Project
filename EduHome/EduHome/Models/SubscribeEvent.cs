using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class SubscribeEvent
    {
        public int Id { get; set; }
        public int SubscribersId { get; set; }
        public Subscribers Subscribers { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
