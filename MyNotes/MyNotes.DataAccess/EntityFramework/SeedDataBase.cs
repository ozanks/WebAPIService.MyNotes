using Microsoft.Extensions.DependencyInjection;
using MyNotes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNotes.DataAccess.EntityFramework
{
    public class SeedDataBase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<MyNotesDbContext>();

            Category category = new Category
            {
                CategoryName = "Sosyal Ağlar"
            };

            if (!context.Categories.Any())
            {
                context.Categories.Add(category);
                
                if (context.SaveChanges()>0)
                {
                    Note note = new Note
                    {
                        NoteTitle = "Yeni not",
                        NoteDescription = "Notumuzun açıklaması",
                        CategoryId = category.Id,
                        Category = category
                    };
                    context.Add(note);
                    context.SaveChanges();
                }
            }
            
        }
    }
}
