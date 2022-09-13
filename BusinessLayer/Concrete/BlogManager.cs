using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogdal;

        public BlogManager(IBlogDal blogdal)
        {
            _blogdal = blogdal;
        }

        public void Add(Blog blog)
        {
            _blogdal.Insert(blog);
        }

        public void Delete(Blog blog)
        {
            _blogdal.Delete(blog);
        }

        public List<Blog> GetBlogListWithCategory()
        {
            var blog = _blogdal.GetListWithCategory().OrderByDescending(x => x.BlogCreadDate).ToList(); ;
            return blog;
        }
        public List<Blog> GetListWithCategoryByWriterBM(int id)
        {
            return _blogdal.GetListWithCategoryByWriter(id).OrderByDescending(x => x.BlogCreadDate).ToList(); ;
        }

        public Blog GetByID(int id)
        {
            var blog = _blogdal.GetById(id);
            return blog;
        }
        public List<Blog> GetBlogById(int id)
        {
            return _blogdal.GetListAll(x => x.BlogId == id);
        }

        public List<Blog> GetList()
        {
            var blog = _blogdal.GetListAll().OrderByDescending(x=>x.BlogCreadDate).ToList();
            return blog;
        }

        public void Update(Blog blog)
        {
            _blogdal.Update(blog);
        }

        public List<Blog> GetBlogListWithWriter(int id)
        {
            var blog = _blogdal.GetListAll(x=>x.WriterId==id).OrderByDescending(x=> x.BlogCreadDate).Take(3).ToList();
            return blog;
        }

        public List<Blog> GetLast3BlogList()
        {
            return _blogdal.GetListAll().OrderByDescending(x=>x.BlogCreadDate).Take(3).ToList();
        }
    }
}
