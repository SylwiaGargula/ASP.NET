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
    public class ProduktsController : Controller
    {
        private gadzeciakContext db = new gadzeciakContext();

        [Authorize(Roles = "Admin")]
        // GET: Produkts
        public ActionResult Index()
        {
            var produkts = db.Produkts.Include(p => p.Kategoria);
            return View(produkts.ToList());
        }
        
        public ActionResult Strona()
        {
            var produkts = db.Produkts.Include(p => p.Kategoria);
            return View(produkts.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Panel()
        {
           
            return View();
        }


        public ActionResult Szczegoly(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Produkts.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            return View(produkt);
        }

        public ActionResult PoKategorii(int? id)
        {
            var produkts = db.Produkts.Where(p => p.IdKategoria==id);

            
            return PartialView(produkts.ToList());

        }

        public ActionResult Sortuj(int? id)
        {
            //przyjmuje id kategorii po ktorej bedzie sortowal
            var produkts = db.Produkts.Where(p => p.IdKategoria == id);
            return PartialView(produkts.ToList());

        }

        public ActionResult WszystkieProdukty()
        {
            var produkts = db.Produkts.Include(p => p.Kategoria);
            return PartialView(produkts.ToList());

        }


        public ActionResult Szukaj(string a)
        {
            var produkts = db.Produkts.Where(p => p.Nazwa == a);
            return PartialView(produkts.ToList());

        }

        [Authorize(Roles = "Admin")]
        // GET: Produkts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Produkts.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            return View(produkt);
        }

        // GET: Produkts/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.IdKategoria = new SelectList(db.Kategorias, "IdKategoria", "Nazwa");
            return View();
        }

        // POST: Produkts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "IdProdukt,Nazwa,Opis,Dostepnosc,OfertaSpecjalna,Polecane,Zdjecie,Zdjecie2,Zdjecie3,Cena,IdKategoria")] Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                db.Produkts.Add(produkt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdKategoria = new SelectList(db.Kategorias, "IdKategoria", "Nazwa", produkt.IdKategoria);
            return View(produkt);
        }

        // GET: Produkts/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Produkts.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdKategoria = new SelectList(db.Kategorias, "IdKategoria", "Nazwa", produkt.IdKategoria);
            return View(produkt);
        }

        // POST: Produkts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "IdProdukt,Nazwa,Opis,Dostepnosc,OfertaSpecjalna,Polecane,Zdjecie,Zdjecie2,Zdjecie3,Cena,IdKategoria")] Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produkt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdKategoria = new SelectList(db.Kategorias, "IdKategoria", "Nazwa", produkt.IdKategoria);
            return View(produkt);
        }

        // GET: Produkts/Delete/5
        [Authorize(Roles = "Admin")]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Produkts.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            return View(produkt);
        }

        // POST: Produkts/Delete/5
        [Authorize(Roles = "Admin")]

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produkt produkt = db.Produkts.Find(id);
            db.Produkts.Remove(produkt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //*********************************PARTIAL VIEW
        [Authorize(Roles = "Admin")]
        public ActionResult IndexPartial()
        {
            var produkts = db.Produkts.Include(p => p.Kategoria);
            return View(produkts.ToList());
        }





        // GET: Produkts/Create
           [Authorize(Roles = "Admin")]
        public ActionResult CreatePartial()
        {
            ViewBag.IdKategoria = new SelectList(db.Kategorias, "IdKategoria", "Nazwa");
            return View();
        }

        // POST: Produkts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult CreatePartial([Bind(Include = "IdProdukt,Nazwa,Opis,Dostepnosc,OfertaSpecjalna,Polecane,Zdjecie,Zdjecie2,Zdjecie3,Cena,IdKategoria")] Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                db.Produkts.Add(produkt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdKategoria = new SelectList(db.Kategorias, "IdKategoria", "Nazwa", produkt.IdKategoria);
            return View(produkt);
        }
















        //**********************

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
