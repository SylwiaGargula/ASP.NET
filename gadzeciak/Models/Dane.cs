using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace gadzeciak.Models
{
    public class Produkt
    {
        [Key]
        public int IdProdukt { get; set; }

        [Required(ErrorMessage ="Nazwa produktu jest wymagana")]
        [Display(Name ="Nazwa produktu")]
        [StringLength(160)]
        public string Nazwa { get; set; }
        [Required(ErrorMessage ="Opis produktu jest wymagany")]
        [Display(Name ="Opis produktu")]
        public string Opis { get; set; }
        [Display(Name ="Czy produkt jest dostępny?")]
        public Boolean Dostepnosc { get; set; }
        [Display(Name ="Czy produkt jest w ofercie specjalnej?")]
        public Boolean OfertaSpecjalna { get; set; }

        [Display(Name ="Czy produkt jest w grupie polecanych?")]
        public Boolean Polecane { get; set; }
        [Display(Name ="Zdjęcie główne produktu")]
        public string Zdjecie { get; set; }

        [Display(Name ="Drugie zdjęcie produktu")]
        public string Zdjecie2 { get; set; }

        [Display(Name ="Trzecie zdjęcie produktu")]
        public string Zdjecie3 { get; set; }
        
        [Required(ErrorMessage ="Podaj cenę produktu")]
        public Double Cena { get; set; }

        [ForeignKey("Kategoria")]
        [Display(Name ="Wybierz kategorię produktu")]
         public int IdKategoria { get; set; }
        public virtual Kategoria Kategoria { get; set; }

    }


    public class Uzytkownik
    {
        [Key]
        public int IdUzytkownik { get; set; }
        [Required(ErrorMessage ="Imię jest wymagane")]
        [Display(Name ="Imię")]
        public string Imie { get; set; }
        [Required(ErrorMessage ="Nazwisko jest wymagane")]
        public string Nazwisko { get; set; }
        [Display(Name ="Adres zamieszkania")]
        [Required(ErrorMessage ="Adres zamieszkania jest wymagany")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Email jest wymagany")]
        [Display(Name = "Adres email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email nie jest prawidłowy.")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required(ErrorMessage ="Hasło jest wymagane")]
        [DataType(DataType.Password)]
        public string Haslo { get; set; }
        [Required(ErrorMessage ="Login użytkownika jest wymagany")]
        [Display(Name ="Login użytkownika")]
       public string NazwaUzytkownika { get; set; }
        
    }

    public class Roles
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }

    public class UserRoles
    {
        [Key]
        [Display(Name="Rola użytkownika")]
        public int UserRolesID { get; set; }
        [ForeignKey("Roles")]
        public int RoleID { get; set; }
        public virtual Roles Roles { get; set; }
        [ForeignKey("Uzytkownik")]
        public int UserID { get; set; }
        public virtual Uzytkownik Uzytkownik { get; set; }

        
    }

    public class Kategoria
    {
        [Key]
        public int IdKategoria { get; set; }
        [Display(Name ="Nazwa kategorii")]
        [Required(ErrorMessage ="Nazwa kategorii jest wymagana")]
        public string Nazwa { get; set; }

        public virtual ICollection<Produkt> Produkty { get; set; }

    }



    public class ElementKoszyka
    {
        [Key]
        public int IdElementKoszyka { get; set; }
        public int Ilosc { get; set; }
        public DateTime DataUtworzenia { get; set; }

        public string IdSesjiKoszyka { get; set; }

        [ForeignKey("Produkt")]
        public int ProduktId { get; set; }
        public virtual Produkt Produkt { get; set; }
        
    }


    public class DaneDoKoszyka
    {
        [Key]
        public int IdDanych { get; set; }
        public virtual List<ElementKoszyka> ElementyKoszyka { get; set; }
        public Double Razem { get; set; }

    }
}