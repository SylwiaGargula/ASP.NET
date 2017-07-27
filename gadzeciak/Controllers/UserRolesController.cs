using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gadzeciak.Models;

namespace gadzeciak.Controllers
{
    public class UserRolesController : Controller
    {
        private gadzeciakContext db = new gadzeciakContext();
        [Authorize(Roles = "Admin")]

        // GET: UserRoles
        public ActionResult Index()
        {
            var userRoles = db.UserRoles.Include(u => u.Roles).Include(u => u.Uzytkownik);
            return View(userRoles.ToList());
        }
        [Authorize(Roles = "Admin")]

        // GET: UserRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRoles userRoles = db.UserRoles.Find(id);
            if (userRoles == null)
            {
                return HttpNotFound();
            }
            return View(userRoles);
        }

        [Authorize(Roles = "Admin")]

        // GET: UserRoles/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName");
            ViewBag.UserID = new SelectList(db.Uzytkowniks, "IdUzytkownik", "Imie");
            return View();
        }

        // POST: UserRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult Create([Bind(Include = "UserRolesID,RoleID,UserID")] UserRoles userRoles)
        {
            if (ModelState.IsValid)
            {
                db.UserRoles.Add(userRoles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", userRoles.RoleID);
            ViewBag.UserID = new SelectList(db.Uzytkowniks, "IdUzytkownik", "Imie", userRoles.UserID);
            return View(userRoles);
        }

        [Authorize(Roles = "Admin")]

        // GET: UserRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRoles userRoles = db.UserRoles.Find(id);
            if (userRoles == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", userRoles.RoleID);
            ViewBag.UserID = new SelectList(db.Uzytkowniks, "IdUzytkownik", "Imie", userRoles.UserID);
            return View(userRoles);
        }

        // POST: UserRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult Edit([Bind(Include = "UserRolesID,RoleID,UserID")] UserRoles userRoles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRoles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", userRoles.RoleID);
            ViewBag.UserID = new SelectList(db.Uzytkowniks, "IdUzytkownik", "Imie", userRoles.UserID);
            return View(userRoles);
        }

        // GET: UserRoles/Delete/5
        [Authorize(Roles = "Admin")]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRoles userRoles = db.UserRoles.Find(id);
            if (userRoles == null)
            {
                return HttpNotFound();
            }
            return View(userRoles);
        }

        // POST: UserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult DeleteConfirmed(int id)
        {
            UserRoles userRoles = db.UserRoles.Find(id);
            db.UserRoles.Remove(userRoles);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //*************************PARTIAL
        [Authorize(Roles = "Admin")]

        public ActionResult IndexPartial()
        {
            var userRoles = db.UserRoles.Include(u => u.Roles).Include(u => u.Uzytkownik);
            return View(userRoles.ToList());
        }


        // GET: UserRoles/Create
        [Authorize(Roles = "Admin")]

        public ActionResult CreatePartial()
        {
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName");
            ViewBag.UserID = new SelectList(db.Uzytkowniks, "IdUzytkownik", "Imie");
            return View();
        }

        // POST: UserRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin")]

        public ActionResult CreatePartial([Bind(Include = "UserRolesID,RoleID,UserID")] UserRoles userRoles)
        {
            if (ModelState.IsValid)
            {
                db.UserRoles.Add(userRoles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", userRoles.RoleID);
            ViewBag.UserID = new SelectList(db.Uzytkowniks, "IdUzytkownik", "Imie", userRoles.UserID);
            return View(userRoles);
        }







        //********************
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
