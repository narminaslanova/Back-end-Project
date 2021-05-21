using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [Required]
        public string Time { get; set; }
       
        public string City { get; set; }
        public string ImageURL { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public bool IsDeleted { get; set; }
        public EventDetails EventDetails { get; set; }
        public List<SpeakerEvent> SpeakerEvents { get; set; }
        public List<SubscribeEvent> SubscribeEvents { get; set; }


    }
}
