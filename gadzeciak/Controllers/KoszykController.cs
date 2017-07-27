using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gadzeciak.Models;

namespace gadzeciak.Controllers
{
    public class KoszykController : Controller
    {
        private gadzeciakContext db = new gadzeciakContext();
        // GET: Koszyk
        [Authorize(Roles = "User")]
        public ActionResult Index()
        {
            KoszykB koszyk = new KoszykB(this.HttpContext);
            var daneDoKoszyka = new DaneDoKoszyka
            {
                ElementyKoszyka = koszyk.GetElementKoszyka(),
                Razem = koszyk.GetRazem()
            };
            
            return View(daneDoKoszyka);
        }
        [Authorize(Roles = "User")]
        public ActionResult DodajDoKoszyka(int id)
        {
            var nowyElementKoszyka =
                 (
                 from p in db.Produkts
                 where p.IdProdukt == id
                 select p
                 ).First();
            KoszykB koszyk = new KoszykB(this.HttpContext);
            koszyk.DodajDoKoszyka(nowyElementKoszyka);
            string aa = Request.Path;
            return RedirectToAction("Strona","Produkts");
            

        }

        [ChildActionOnly]
        [Authorize(Roles = "User")]
        public ActionResult LiczbaTowarowWKoszyku()
        {
            KoszykB koszyk = new KoszykB(this.HttpContext);
            ViewData["LiczbaTowarowWKoszyku"] = koszyk.GetIlosc();
            ViewData["WartoscTowarowWKoszyku"] = koszyk.GetRazem();
            return PartialView();

        }
        [Authorize(Roles = "User")]
        public ActionResult UsunZKoszyka(int id)
        {
            KoszykB koszyk = new KoszykB(this.HttpContext);
            koszyk.UsunZKoszyka(id);
            return RedirectToAction("Index", "Koszyk");

        }
        [Authorize(Roles = "User")]
        public ActionResult UsunWszystkieZKoszyka()
        {
            KoszykB koszyk = new KoszykB(this.HttpContext);
            koszyk.UsunWszystkieZKoszyka();
            return RedirectToAction("Index", "Koszyk");

        }
    }
}