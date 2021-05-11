using EduHome.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<CoursesDetails> CourseDetailes { get; set; }
        public DbSet<CourseFeatures> CourseFeatures { get; set; }
        public DbSet<NoticeBoard> NoticeBoards { get; set; }
        public DbSet<InfoCard> InfoCards { get; set; }
        public DbSet<AboutInfo> AboutInfos { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventDetails> EventDetails { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Bio>  Bios { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherDetails> TeacherDetails { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }

    }
}
