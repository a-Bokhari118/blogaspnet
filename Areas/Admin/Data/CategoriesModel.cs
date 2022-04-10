using blog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace blog.Areas.Admin.Data
{
    public class CategoriesModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        public virtual ICollection<Posts> Posts { get; set; }
    }
}