
using MyNotes.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyNotes.Entities
{
    public class Note:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string NoteTitle { get; set; }
        public string NoteDescription { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }

}
