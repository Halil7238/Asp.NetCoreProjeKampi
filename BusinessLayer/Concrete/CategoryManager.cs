﻿using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryServices
    {
        EfCategoryRepository efCategoryRepository;
        public void Add(Category category)
        {
            efCategoryRepository.Insert(category);
        }

        public void Delete(Category category)
        {
            efCategoryRepository.Delete(category);
        }

        public Category GetById(int id)
        {
            return efCategoryRepository.GetById(id);
        }

        public List<Category> GetList()
        {
            return efCategoryRepository.GetListAll();
        }

        public void Update(Category category)
        {
            efCategoryRepository.Update(category);
        }
    }
}