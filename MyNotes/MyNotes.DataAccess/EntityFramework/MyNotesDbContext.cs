using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MyNotes.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNotes.DataAccess.EntityFramework
{
    public class MyNotesDbContext : DbContext
    {
        public MyNotesDbContext(DbContextOptions<MyNotesDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Note> Notes { get; set; }
        

    }
}
