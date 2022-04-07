using blog.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blog.Areas.Admin.Controllers
{
    public class RolesController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Roles
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        public ActionResult GetAllRoles()
        {
            var data = db.Roles.ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }



        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(string id)
        {
            var role = db.Roles.Find(id);
            if (role == null)
            {
                return PartialView("~~Area/Admin/Views/Shared/notfounpage.cshtml");
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name")] IdentityRole role)
        {

            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Roles/Delete/5
        /*  public ActionResult Delete(string id)
          {
              var role = db.Roles.Find(id);
              if (role == null)
              {
                  return PartialView("~Area/Admin/Views/Shared/notfounpage.cshtml");
              }
              return View(role);

          }*/

        // POST: Roles/Delete/5
        /*  [HttpPost]
          public ActionResult Delete(IdentityRole role)
          {
              try
              {
                  var myrole = db.Roles.Find(role.Id);
                  db.Roles.Remove(myrole);
                  db.SaveChanges();
                  return RedirectToAction("Index");
              }
              catch
              {
                  return View(role);
              }
          }*/


        [HttpPost]
        public ActionResult Delete(string id)
        {
            var newid = id.ToString();
            var model = db.Roles.Where(x => x.Id == newid).SingleOrDefault();

            db.Roles.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        /*
                [HttpPost]
                public ActionResult DeleteJson(string id)
                {

                    try
                    {
                        var myrole = db.Roles.Where(x => x.Id == id).FirstOrDefault();
                        db.Roles.Remove(myrole);
                        db.SaveChanges();
                        return Json(new { data = "ok" }, JsonRequestBehavior.AllowGet);
                    }
                    catch
                    {
                        return Json(new { data = "No" }, JsonRequestBehavior.AllowGet);
                    }
                }*/
    }
}