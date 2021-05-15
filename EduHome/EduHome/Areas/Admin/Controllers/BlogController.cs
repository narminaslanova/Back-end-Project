using EduHome.DAL;
using EduHome.Extensions;
using EduHome.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public BlogController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _context.Blogs.Where(b=>b.IsDeleted==false).Include(b => b.BlogDetails).ToListAsync();
            return View(blogs);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog)
        {
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View();
            if (!blog.Photo.IsValidType("image/"))
            {
                ModelState.AddModelError("", "Please select image type");
                return View();
            }
            if (!blog.Photo.IsValidSize(200))
            {
                ModelState.AddModelError("", "Image size should be less than 200kb");
                return View();
            }
            string filepath = Path.Combine("img", "blog");
            Blog newBlog = new Blog
            {
                ImageURL = await blog.Photo.SaveFileAsync(_env.WebRootPath, filepath),
                Title=blog.Title,
                Author=blog.Author,
                Date=blog.Date,
                BlogDetails=blog.BlogDetails
                
            };
            

            BlogDetails blogDetails = new BlogDetails
            {
                Description = blog.BlogDetails.Description,
                BlogId= blog.BlogDetails.BlogId,
                Blog = blog.BlogDetails.Blog
                
            };
            

            await _context.Blogs.AddAsync(newBlog);
           
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Blog blog =await _context.Blogs.Include(b => b.BlogDetails).FirstOrDefaultAsync(b => b.Id == id);
            if (blog == null) return NotFound();
            return View(blog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Blog blog)
        {
            
            Blog oldBlog =await _context.Blogs.Include(b => b.BlogDetails).FirstOrDefaultAsync(c => c.Id == id);
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View();
            if (!blog.Photo.IsValidType("image/"))
            {
                ModelState.AddModelError("", "Please select image type");
                return View();
            }
            if (!blog.Photo.IsValidSize(200))
            {
                ModelState.AddModelError("", "Image size should be less than 200kb");
                return View();
            }
            string filepath = Path.Combine("img", "blog");

            oldBlog.ImageURL = await blog.Photo.SaveFileAsync(_env.WebRootPath, filepath);

            oldBlog.Id = id;
            oldBlog.Title = blog.Title;
            oldBlog.Author = blog.Author;
            oldBlog.Date = blog.Date;
            oldBlog.BlogDetails = blog.BlogDetails;

            oldBlog.BlogDetails.Id = blog.BlogDetails.Id;

            oldBlog.BlogDetails.Description = blog.BlogDetails.Description;
            oldBlog.BlogDetails.BlogId = blog.BlogDetails.BlogId;
            oldBlog.BlogDetails.Blog = blog.BlogDetails.Blog;

            _context.Update(oldBlog);
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            Blog blog =await _context.Blogs.Include(b => b.BlogDetails).FirstOrDefaultAsync(b => b.Id == id);
            if (blog == null) return NotFound();
            return View(blog);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Blog blog =await _context.Blogs.Include(b => b.BlogDetails).FirstOrDefaultAsync(b=>b.Id==id);
            if (blog.IsDeleted == false)
            {
                blog.IsDeleted = true;
            }
            else
            {
                blog.IsDeleted = false;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
