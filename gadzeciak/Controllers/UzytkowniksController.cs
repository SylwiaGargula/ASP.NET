using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gadzeciak.Models;
using System.Web.Security;

namespace gadzeciak.Controllers
{
    public class UzytkowniksController : Controller
    {
        private gadzeciakContext db = new gadzeciakContext();

        // GET: Uzytkowniks
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Uzytkowniks.ToList());
        }

/*
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Uzytkownik u)
        {
            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {
                using (gadzeciakContext dc = new gadzeciakContext())
                {
                    var v = dc.Uzytkowniks.Where(a => a.NazwaUzytkownika.Equals(u.NazwaUzytkownika) && a.Haslo.Equals(u.Haslo)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.IdUzytkownik.ToString();
                        Session["LogedUserFullname"] = v.NazwaUzytkownika.ToString();
                        return RedirectToAction("AfterLogin","Uzytkowniks");
                    }
                }
            }
            return View(u);
        }
        */
        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Strona","Produkts");
            }
        }

    
        //***************NOWE
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Uzytkownik l, string ReturnUrl = "")
        {
            using (gadzeciakContext dc = new gadzeciakContext())
            {
                var user = dc.Uzytkowniks.Where(a => a.NazwaUzytkownika.Equals(l.NazwaUzytkownika) && a.Haslo.Equals(l.Haslo)).FirstOrDefault();
                if (user != null)
                {
                    Session["LogedUserID"] = user.IdUzytkownik.ToString();
                    Session["LogedUserFullname"] = user.NazwaUzytkownika.ToString();
                    Session["LogedUserName"] = user.Imie.ToString();
                    Session["LogedUserSurname"] = user.Nazwisko.ToString();
                    Session["LogedUserEmail"] = user.Email.ToString();

                    FormsAuthentication.SetAuthCookie(user.NazwaUzytkownika,false);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("AfterLogin", "Uzytkowniks");
                    }
                }
            }
        //    ModelState.Remove("Haslo");
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Strona", "Produkts");
        }

        //************




        [Authorize(Roles = "Admin")]

        // GET: Uzytkowniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzytkownik uzytkownik = db.Uzytkowniks.Find(id);
            if (uzytkownik == null)
            {
                return HttpNotFound();
            }
            return View(uzytkownik);
        }

        // GET: Uzytkowniks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Uzytkowniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUzytkownik,Imie,Nazwisko,Adres,Email,Haslo,NazwaUzytkownika")] Uzytkownik uzytkownik)
        {
            if (ModelState.IsValid)
            {
                db.Uzytkowniks.Add(uzytkownik);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(uzytkownik);
        }
        [Authorize(Roles = "Admin")]

        // GET: Uzytkowniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzytkownik uzytkownik = db.Uzytkowniks.Find(id);
            if (uzytkownik == null)
            {
                return HttpNotFound();
            }
            return View(uzytkownik);
        }

        // POST: Uzytkowniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult Edit([Bind(Include = "IdUzytkownik,Imie,Nazwisko,Adres,Email,Haslo,NazwaUzytkownika")] Uzytkownik uzytkownik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uzytkownik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uzytkownik);
        }

        // GET: Uzytkowniks/Delete/5
        [Authorize(Roles = "Admin")]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzytkownik uzytkownik = db.Uzytkowniks.Find(id);
            if (uzytkownik == null)
            {
                return HttpNotFound();
            }
            return View(uzytkownik);
        }

        // POST: Uzytkowniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult DeleteConfirmed(int id)
        {
            Uzytkownik uzytkownik = db.Uzytkowniks.Find(id);
            db.Uzytkowniks.Remove(uzytkownik);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
