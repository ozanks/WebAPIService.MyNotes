using MyNotes.Core.EntityFramework;
using MyNotes.DataAccess.Abstract;
using MyNotes.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNotes.DataAccess.EntityFramework
{
    public class CategoryDal : RepositoryBase<Category, MyNotesDbContext>, ICategoryRepository
    {
        public CategoryDal(MyNotesDbContext context) : base(context)
        {
        }
    }
}
