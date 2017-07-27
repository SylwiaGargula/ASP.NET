using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace gadzeciak.Models
{
    public class Zamowienie
    {
        [Key]
        public int IdZamowienia { get; set; }
        public System.DateTime DataZamowienia { get; set; }
        

        [Required(ErrorMessage = "Ulica jest wymagana")]
        [StringLength(70)]
        public string Ulica { get; set; }

        [Required(ErrorMessage = "Miasto jest wymagane")]
        [StringLength(70)]
        public string Miasto { get; set; }

        [Required(ErrorMessage = "Województwo jest wymagane")]
        [StringLength(70)]
        [Display(Name = "Województwo")]
        public string Wojewodztwo { get; set; }

        [Required(ErrorMessage = "Kod pocztowy jest wymagany")]
        [Display(Name = "Kod Pocztowy")]
        [StringLength(10)]
        public string KodPocztowy { get; set; }

        [Required(ErrorMessage = "Państwo jest wymagane")]
        [StringLength(70)]
        [Display(Name = "Państwo")]
        public string Panstwo { get; set; }

        [Required(ErrorMessage = "Numer telefonu jest wymagany")]
        [StringLength(24)]
        [Display(Name = "Numer telefonu")]
        public string NumerTelefonu { get; set; }
        
        public Double Total { get; set; }

        public virtual ICollection<PozycjaZamowienia> PozycjaZamowienia { get; set; }

       

    }
}