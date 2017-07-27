using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gadzeciak.Models;

namespace gadzeciak.Models
{
    public class KoszykB
    {
        private gadzeciakContext db;
        private string IdSesjiKoszyka;
        public KoszykB(HttpContextBase context)
        {
            this.db = new gadzeciakContext();
            this.IdSesjiKoszyka = GetIdSesjiKoszyka(context);

        }
        private string GetIdSesjiKoszyka(HttpContextBase context)
        {
            if (context.Session[IdSesjiKoszyka] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[IdSesjiKoszyka] = context.User.Identity.Name;

                }
                else
                {
                    Guid tempIdSesjiKoszyka = Guid.NewGuid();
                    context.Session[IdSesjiKoszyka] = tempIdSesjiKoszyka.ToString();
                }

            }
            return context.Session[IdSesjiKoszyka].ToString();
        }

        public List<ElementKoszyka> GetElementKoszyka()
        {
            List<ElementKoszyka> ListaElementowKoszyka = db.ElementKoszykas.Where(p => p.IdSesjiKoszyka == this.IdSesjiKoszyka).ToList();
            return ListaElementowKoszyka;
        }

        public Double GetRazem()
        {
           
            Double? razem =
                (
                from p in db.ElementKoszykas
                where p.IdSesjiKoszyka == this.IdSesjiKoszyka
                select (Double?)p.Ilosc * p.Produkt.Cena
                ).Sum();
            return razem ?? Double.Epsilon;

        }

        public void DodajDoKoszyka(Produkt produkt)
        {

            var elementKoszyka =
                (
                from p in db.ElementKoszykas
                where p.IdSesjiKoszyka == this.IdSesjiKoszyka && p.ProduktId == produkt.IdProdukt
                select p
                ).FirstOrDefault();

            if (elementKoszyka == null)
            {
                elementKoszyka = new ElementKoszyka()
                {
                    IdSesjiKoszyka = this.IdSesjiKoszyka,
                    ProduktId = produkt.IdProdukt,
                    Ilosc = 1,
                    DataUtworzenia = DateTime.Now

                };
                db.ElementKoszykas.Add(elementKoszyka);

            }
            else
            {
                elementKoszyka.Ilosc++;
            }
            db.SaveChanges();
        }


        public int GetIlosc()
        {
            int? ilosc =
                (
                from p in db.ElementKoszykas
                where p.IdSesjiKoszyka == IdSesjiKoszyka
                select (int?)p.Ilosc
                ).Sum();
            return ilosc ?? 0;
        }

        public void UsunZKoszyka(int id)
        {
            var elementKoszyka =
                (
                from p in db.ElementKoszykas
                where p.IdSesjiKoszyka == IdSesjiKoszyka && p.ProduktId == id
                select p
                ).FirstOrDefault();
            if(elementKoszyka!=null)
            {
                db.ElementKoszykas.Remove(elementKoszyka);
                db.SaveChanges();
            }
        }

        public void UsunWszystkieZKoszyka()
        {

            var elementyKoszyka =
                (
                from p in db.ElementKoszykas
                where p.IdSesjiKoszyka == IdSesjiKoszyka
                select p
                );
            if(elementyKoszyka!=null)
            {
                foreach(var p in elementyKoszyka)
                {
                    db.ElementKoszykas.Remove(p);
                }
                db.SaveChanges();
            }
        }

        
        public int UtworzZamowienie(Zamowienie zamowienie)
        {
            Double wartoscZamowienia = 0;
            var elementyKoszyka = GetElementKoszyka();
            db.Zamowienies.Add(zamowienie);
            //db.SaveChanges();
            foreach (var element in elementyKoszyka)
            {
                var pozycjaZamowienia = new PozycjaZamowienia
                {
                    IdProdukt = element.ProduktId,
                    IdZamowienia = zamowienie.IdZamowienia,
                    Cena = element.Produkt.Cena,
                    Ilosc = element.Ilosc
                };
                wartoscZamowienia += (element.Ilosc * element.Produkt.Cena);
                db.PozycjaZamowienias.Add(pozycjaZamowienia);
            }

            zamowienie.Total = wartoscZamowienia;
            db.SaveChanges();
            UsunWszystkieZKoszyka();
            return zamowienie.IdZamowienia;
        }
        
    

    }
}