using blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace blog.Areas.Admin.Controllers
{
    public class PostsAdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Posts
        public ActionResult Index()
        {
            IEnumerable<Posts> posts = db.Posts.Where(x => x.isDeleted == false).ToList();
            return View(posts);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posts post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.CategoriesModels, "Id", "Name", post.CategoryId);
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Posts model, HttpPostedFileBase BlogImage)
        {

            if (ModelState.IsValid)
            {
                string oldPath = Path.Combine(Server.MapPath("~/Uploads"), model.BlogImage);
                if (BlogImage != null)
                {
                    System.IO.File.Delete(oldPath);
                    string filename = Path.GetFileNameWithoutExtension(BlogImage.FileName);
                    string ext = Path.GetExtension(BlogImage.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + ext;
                    string path = Path.Combine(Server.MapPath("~/Uploads"), filename);
                    BlogImage.SaveAs(path);
                    model.BlogImage = filename;
                }

                model.CreatedAt = DateTime.Now;
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.CategoriesModels, "Id", "Name", model.CategoryId);
            return View(model);
        }



        [HttpPost]
        public ActionResult Delete(int? id)
        {
            Posts p = db.Posts.Where(x => x.Id == id).FirstOrDefault();
            p.isDeleted = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}