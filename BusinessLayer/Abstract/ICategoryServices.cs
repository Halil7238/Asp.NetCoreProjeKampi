using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryServices
    {
        void Add(Category category);
        void Delete(Category category);
        List<Category> GetList();
        Category GetById(int id);
        void Update(Category category);
        List<Category> GetCategoryListWithBlog();
    }
}
