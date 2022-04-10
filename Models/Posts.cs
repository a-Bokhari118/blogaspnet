using blog.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blog.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CategoryId { get; set; }

        public string Title { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool isDeleted { get; set; }
        [Display(Name = "Main Image")]
        public string BlogImage { get; set; }

        public virtual CategoriesModel Category { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}