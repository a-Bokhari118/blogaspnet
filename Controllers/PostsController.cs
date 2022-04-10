using blog.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blog.Controllers
{
    public class PostsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Posts
        public ActionResult Index()
        {
            IEnumerable<Posts> posts = db.Posts.Where(x => x.isDeleted == false).ToList();
            return View(posts);
        }

        public ActionResult Details(int id)
        {
            Posts post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.CategoriesModels, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Posts model, HttpPostedFileBase BlogImage)
        {

            if (ModelState.IsValid)
            {
                string filename = Path.GetFileNameWithoutExtension(BlogImage.FileName);
                string ext = Path.GetExtension(BlogImage.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + ext;
                string path = Path.Combine(Server.MapPath("~/Uploads"), filename);
                BlogImage.SaveAs(path);
                model.BlogImage = filename;
                model.UserId = User.Identity.GetUserId();
                model.CreatedAt = DateTime.Now;
                model.isDeleted = false;
                db.Posts.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.CategoriesModels, "Id", "Name", model.CategoryId);
            return View(model);
        }
    }
}