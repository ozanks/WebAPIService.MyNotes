using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyNotes.WebAPIService.Models
{
    public class CategoryModel
    {
        [Required(ErrorMessage ="Kategori ismi boş geçilemez!")]
        public string CategoryName { get; set; }
    }
}
