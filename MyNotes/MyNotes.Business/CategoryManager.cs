using MyNotes.Business.Abstract;
using MyNotes.DataAccess.Abstract;
using MyNotes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyNotes.Business
{
    public class CategoryManager : ICategoryService
    {
        ICategoryRepository repo;

        public CategoryManager(ICategoryRepository repo)
        {
            this.repo = repo;
        }

        public void Add(Category entity)
        {
            repo.Add(entity);
        }

        public void Delete(Category entity)
        {
            repo.Delete(entity);
        }

        public List<Category> GetAll()
        {
            return repo.GetAll().ToList();
        }

        public Category GetById(int id)
        {
            return repo.GetById(id);
        }

        public List<Category> GetEx(Expression<Func<Category, bool>> predicate)
        {
            return repo.GetEx(predicate).ToList();
        }
        
        public void Update(Category entity)
        {
            repo.Update(entity);
        }
    }
}
