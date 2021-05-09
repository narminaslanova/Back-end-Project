using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class NoticeBoardViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public NoticeBoardViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int take)
        {
            List<NoticeBoard> noticeBoards = _context.NoticeBoards.Take(take).ToList();
            return View(await Task.FromResult(noticeBoards));
        }
    }
}
