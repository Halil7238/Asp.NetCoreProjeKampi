using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        //BlogReadAll
        [HttpGet]
        public IActionResult BlogDetail(int id)
        {
            ViewBag.BlogId = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult BlogDetail(Comment c , int id)
        {
            c.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.CommentStatus = true;
            c.BlogId = id;
            cm.Add(c);
            return RedirectToAction("BlogDetail", "Blog");
        }
        
    }
}
