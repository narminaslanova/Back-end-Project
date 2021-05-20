using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        public string ImageURL { get; set; }
        [NotMapped, Required]
        public IFormFile Photo { get; set; }
        public string Author { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [Required]
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public BlogDetails BlogDetails { get; set; }
    }
}
