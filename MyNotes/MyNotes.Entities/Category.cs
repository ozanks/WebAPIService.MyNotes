
using MyNotes.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyNotes.Entities
{
    public class Category:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public List<Note> Notes { get; set; }


    }

}
