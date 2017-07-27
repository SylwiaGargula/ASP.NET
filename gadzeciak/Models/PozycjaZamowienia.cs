using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gadzeciak.Models
{
    public class PozycjaZamowienia
    {
        [Key]
        public int IdPozycjiZamowienia { get; set; }
        public int Ilosc { get; set; }
        public Double Cena { get; set; }

        public int IdProdukt { get; set; }
        public virtual Produkt Produkt { get; set; }

        public int IdZamowienia { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }

    }
}