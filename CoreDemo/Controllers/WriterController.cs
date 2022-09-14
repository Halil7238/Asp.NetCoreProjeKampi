using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer.Concrete;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();

        public IActionResult Index()
        {
            ViewBag.BlogCount = c.Blogs.Count();
            ViewBag.BlogByWriterCount = c.Blogs.Where(x=>x.WriterId==1).Count();
            ViewBag.CategoryCount = c.Categories.Count();
            //var values = bm.GetList();
            return View(/*values*/);
        }
        public IActionResult BlogListByWriter()
        {
            var values = bm.GetListWithCategoryByWriterBM(1);
            return View(values);
        }

        public PartialViewResult NavbarMenuTop()
        {
            return PartialView();
        }
        public PartialViewResult NavbarMenuLeft()
        {
            return PartialView();
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {

            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategroyName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(blog);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategroyName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            if (results.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreadDate = DateTime.Parse(DateTime.Now.ToString());
                blog.WriterId = 1;
                bm.Add(blog);
                return RedirectToAction("BlogListByWriter", "Writer");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.GetByID(id);
            bm.Delete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult BlogUpdate(int id)
        {
            var blogvalue = bm.GetByID(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategroyName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View(blogvalue);
        }
        [HttpPost]
        public IActionResult BlogUpdate(Blog blog)
        {

            bm.Update(blog);
            return RedirectToAction("BlogListByWriter");

        }


    }
}
