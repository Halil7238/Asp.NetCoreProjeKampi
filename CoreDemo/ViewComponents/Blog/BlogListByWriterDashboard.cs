using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
    public class BlogListByWriterDashboard :ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = bm.GetListWithCategoryByWriterBM(1);
            return View(values);
        }
    }
}
