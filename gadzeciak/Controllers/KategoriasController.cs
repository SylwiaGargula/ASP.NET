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
    public class KategoriasController : Controller
    {
        private gadzeciakContext db = new gadzeciakContext();
        [Authorize(Roles = "Admin")]
        // GET: Kategorias
        public ActionResult Index()
        {
            return View(db.Kategorias.ToList());
        }
        [Authorize(Roles = "Admin")]
        // GET: Kategorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoria kategoria = db.Kategorias.Find(id);
            if (kategoria == null)
            {
                return HttpNotFound();
            }
            return View(kategoria);
        }
        [Authorize(Roles = "Admin")]
        // GET: Kategorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "IdKategoria,Nazwa")] Kategoria kategoria)
        {
            if (ModelState.IsValid)
            {
                db.Kategorias.Add(kategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategoria);
        }
        [Authorize(Roles = "Admin")]
        // GET: Kategorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoria kategoria = db.Kategorias.Find(id);
            if (kategoria == null)
            {
                return HttpNotFound();
            }
            return View(kategoria);
        }

        // POST: Kategorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "IdKategoria,Nazwa")] Kategoria kategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategoria);
        }

        // GET: Kategorias/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoria kategoria = db.Kategorias.Find(id);
            if (kategoria == null)
            {
                return HttpNotFound();
            }
            return View(kategoria);
        }

        // POST: Kategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategoria kategoria = db.Kategorias.Find(id);
            db.Kategorias.Remove(kategoria);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //*******************************Partial View

        [Authorize(Roles = "Admin")]
        public ActionResult IndexPartial()
        {
            return View(db.Kategorias.ToList());
        }


        [Authorize(Roles = "Admin")]
        public ActionResult CreatePartial()
        {
            return View();
        }

        // POST: Kategorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult CreatePartial([Bind(Include = "IdKategoria,Nazwa")] Kategoria kategoria)
        {
            if (ModelState.IsValid)
            {
                db.Kategorias.Add(kategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategoria);
        }






        //*******************************



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
