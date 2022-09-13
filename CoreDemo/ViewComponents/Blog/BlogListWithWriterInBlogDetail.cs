using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writers
{
    public class BlogListWithWriterInBlogDetail :ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        WriterManager wm = new WriterManager(new EfWriterRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = bm.GetBlogListWithWriter(id);
            return View(values);
        }
    }
}
