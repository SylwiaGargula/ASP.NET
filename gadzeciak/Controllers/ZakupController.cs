using gadzeciak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gadzeciak.Controllers
{
    public class ZakupController : Controller
    {
        private gadzeciakContext db = new gadzeciakContext();
        [Authorize(Roles = "User")]

        public ActionResult Dane()
        {
            KoszykB koszyk = new KoszykB(this.HttpContext);
            ViewData["wartosc"] = koszyk.GetRazem();
            ViewData["ilosc"] = koszyk.GetIlosc();

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "User")]

        public ActionResult Dane(FormCollection values)
        {
            var zamowienie = new Zamowienie();
            try
            {
                TryUpdateModel(zamowienie);
                zamowienie.DataZamowienia = DateTime.Now;
                var koszykB = new KoszykB(this.HttpContext);
                int idZamowienia = koszykB.UtworzZamowienie(zamowienie);
                return RedirectToAction("Podsumowanie", new { id = idZamowienia });
            }
            catch
            {
                return View(zamowienie);
            }
        }
        [Authorize(Roles = "User")]

        public ActionResult Podsumowanie(int id)
        {
            var noweZamowienie =
                (
                    from zamowienie in db.Zamowienies
                    where zamowienie.IdZamowienia == id
                    select zamowienie
                ).First();

            if (noweZamowienie != null)
            {
                return View(noweZamowienie);
            }
            else
            {
                return View("Error");
            }
        }


    }
}