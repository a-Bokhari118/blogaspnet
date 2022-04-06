using blog.Areas.Admin.Data;
using blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace blog.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View(db.CategoriesModels.ToList());
        }

        public ActionResult GetAllCategories()
        {
            var categories = db.CategoriesModels.ToList<CategoriesModel>();
            return Json(new { data = categories }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoriesModel model)
        {
            if (ModelState.IsValid)
            {
                db.CategoriesModels.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var category = db.CategoriesModels.SingleOrDefault(x => x.Id == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(CategoriesModel model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}