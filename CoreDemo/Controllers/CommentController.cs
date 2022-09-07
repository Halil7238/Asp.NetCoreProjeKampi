using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult AddCommentPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddCommentPartial(Comment c )
        {
            c.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.CommentStatus = true;
            c.BlogId = 2;
           cm.Add(c);
            return PartialView();
        }
        public PartialViewResult CommentListPartial(int id)
        {
            var values = cm.GetList(id);
            return PartialView(values);
        }
    }
}
